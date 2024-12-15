using AutoMapper;
using ExemploDDD.Communication.Request;
using ExemploDDD.Domain.Entities;
using ExemploDDD.Domain.Repositories;
using ExemploDDD.Domain.Repositories.User;
using ExemploDDD.Domain.Security.Cryptography;
using ExemploDDD.Exceptions.ExceptionBase;

namespace ExemploDDD.Application.UseCases.User.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IPasswordEncrypter _cryptography;
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterUserUseCase(IPasswordEncrypter cryptography, IUserWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _cryptography = cryptography;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task ExecuteAsync(RegisterUserRequest userRequest)
    {
        await Validate(userRequest);

        var user = _mapper.Map<Domain.Entities.User>(userRequest);

        user.Password = _cryptography.Encrypt(userRequest.Password);

        await _repository.CreateUserAsync(user);

        await _unitOfWork.Commit();
    }

    private static async Task Validate(RegisterUserRequest request)
    {
        var validator = new RegisterUserValidator();

        var result = await validator.ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
