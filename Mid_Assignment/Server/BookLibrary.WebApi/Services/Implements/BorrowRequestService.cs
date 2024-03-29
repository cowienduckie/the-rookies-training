﻿using System.Linq.Expressions;
using BookLibrary.Data.Entities;
using BookLibrary.Data.Interfaces;
using BookLibrary.WebApi.Dtos.BorrowRequest;
using BookLibrary.WebApi.Filters;
using BookLibrary.WebApi.Helpers;
using BookLibrary.WebApi.Services.Interfaces;
using Common.Constants;
using Common.DataType;
using Common.Enums;
using Common.Wrappers;

namespace BookLibrary.WebApi.Services.Implements;

public class BorrowRequestService : IBorrowRequestService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBorrowRequestRepository _borrowRequestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BorrowRequestService(
        IUnitOfWork unitOfWork, IBorrowRequestRepository borrowRequestRepository, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _borrowRequestRepository = borrowRequestRepository;
        _bookRepository = bookRepository;
    }

    public async Task<CreateBorrowRequestResponse?> CreateAsync(CreateBorrowRequestRequest requestModel)
    {
        if (requestModel.Requester == null) return null;

        var bookIds = requestModel.BookIds.Distinct();

        var books = (List<Book>) await _bookRepository
            .GetAllAsync(book => bookIds.Contains(book.Id));

        if (books.Count != bookIds.Count()) return null;

        var newBorrowRequest = new BorrowRequest
        {
            Status = RequestStatus.Waiting,
            Books = books,
            RequestedBy = requestModel.Requester.Id,
            RequestedAt = DateTime.UtcNow
        };

        var createdBorrowRequest = _borrowRequestRepository.Create(newBorrowRequest);

        await _unitOfWork.SaveChangesAsync();

        return new CreateBorrowRequestResponse(createdBorrowRequest);
    }

    public async Task<IPagedList<GetBorrowRequestResponse>> GetPagedListAsync(
        GetBorrowRequestRequest request,
        PagingFilter pagingFilter,
        SortFilter sortFilter)
    {
        Expression<Func<BorrowRequest, bool>>? predicate = null;

        if (request.Requester.Role == Role.NormalUser) predicate = br => br.Requester.Id == request.Requester.Id;

        var borrowRequests =
            (await _borrowRequestRepository.GetAllAsync(predicate))
            .AsQueryable();

        var validSortFields = new[]
        {
            SortField.Id,
            SortField.RequestedAt,
            SortField.RequestedBy,
            SortField.ApprovedAt,
            SortField.ApprovedBy,
            SortField.Status
        };

        var sortedBorrowRequests = borrowRequests
            .SortData(validSortFields, sortFilter.SortField, sortFilter.SortOrder)
            .Select(br => new GetBorrowRequestResponse(br))
            .AsQueryable();

        return new PagedList<GetBorrowRequestResponse>
            (sortedBorrowRequests, pagingFilter.PageIndex, pagingFilter.PageSize);
    }

    public async Task<GetBorrowRequestResponse?> GetByIdAsync(GetBorrowRequestRequest request)
    {
        if (request.Id == null) return null;

        Expression<Func<BorrowRequest, bool>> predicate = borrowRequest => borrowRequest.Id == request.Id;

        if (request.Requester.Role == Role.NormalUser)
            predicate = br => br.Requester.Id == request.Requester.Id &&
                              br.Id == request.Id;

        var borrowRequest = await _borrowRequestRepository.GetSingleAsync(predicate);

        if (borrowRequest == null) return null;

        return new GetBorrowRequestResponse(borrowRequest);
    }

    public bool IsExist(int id)
    {
        return _borrowRequestRepository.IsExist(borrowRequest => borrowRequest.Id == id);
    }

    public async Task<ValidCheckingWrapper> IsRequestValid(CreateBorrowRequestRequest request)
    {
        if (request.Requester == null) return new ValidCheckingWrapper(ErrorMessages.RequestHasNoRequester);

        var booksPerRequestCheckingResult = IsBooksPerRequestValid(request);

        if (!booksPerRequestCheckingResult.IsValid) return booksPerRequestCheckingResult;

        var requestsPerMonthCheckingResult = await IsRequestsPerMonthValid(request);

        if (!requestsPerMonthCheckingResult.IsValid) return requestsPerMonthCheckingResult;

        return new ValidCheckingWrapper();
    }

    public async Task<ApproveBorrowRequestResponse?> ApproveAsync(ApproveBorrowRequestRequest requestModel)
    {
        if (requestModel.Approver == null) return null;

        var borrowRequest =
            await _borrowRequestRepository.GetSingleAsync(borrowRequest => borrowRequest.Id == requestModel.Id);

        if (borrowRequest == null) return null;

        borrowRequest.Status = requestModel.IsApproved
            ? RequestStatus.Approved
            : RequestStatus.Rejected;
        borrowRequest.ApprovedBy = requestModel.Approver.Id;
        borrowRequest.ApprovedAt = DateTime.UtcNow;

        var updatedBorrowRequest = _borrowRequestRepository.Update(borrowRequest);

        await _unitOfWork.SaveChangesAsync();

        return new ApproveBorrowRequestResponse(updatedBorrowRequest);
    }

    private static ValidCheckingWrapper IsBooksPerRequestValid(CreateBorrowRequestRequest request)
    {
        if (request.BookIds.Count < Settings.MinBooksPerRequest)
            return new ValidCheckingWrapper(ErrorMessages.BooksPerRequestLimitNotReached);

        if (request.BookIds.Count > Settings.MaxBooksPerRequest)
            return new ValidCheckingWrapper(ErrorMessages.BooksPerRequestLimitExceeded);

        return new ValidCheckingWrapper();
    }

    private async Task<ValidCheckingWrapper> IsRequestsPerMonthValid(CreateBorrowRequestRequest request)
    {
        var currentMonth = DateTime.UtcNow.Month;

        var bookRequestsThisMonth = await _borrowRequestRepository
            .GetAllAsync(br =>
                br.RequestedBy == request.Requester!.Id &&
                br.RequestedAt.Month == currentMonth);

        if (bookRequestsThisMonth.Count() >= Settings.MaxBorrowRequestsPerMonth)
            return new ValidCheckingWrapper(ErrorMessages.RequestsPerMonthLimitExceeded);

        return new ValidCheckingWrapper();
    }
}