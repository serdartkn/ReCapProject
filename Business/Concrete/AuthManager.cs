using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Result.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

public class AuthManager : IAuthService
{
    //kullanıcı zaten kayırlımı kontrolu ıcın bırayu yazıyoruz
    private IUserService _userService;
    //Token uretmek ıcın yazıyouz bunuda
    private ITokenHelper _tokenHelper;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {

        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    //Kayıt olmak ıcın gereklı operasyonndur.
    // kayıt olmak ıcın bır dto ostıyoruz.
    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        var user = new User
        {
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        _userService.Add(user);
        return new SuccessDataResult<User>(user, Messages.UserRegistered);
    }

    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        //Burada mail kullanıcın login yaptıgı maıl dbde vrmı yok mu bakıyoruz yoksa kullanı yok dıyoruz varsa sıfre sıfre konrolune gcıyor sıra.
        var userToCheck = _userService.GetByMail(userForLoginDto.Email);
        if (userToCheck == null)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }
        //burada hashınhelper a passwordlerı gonderıp konrrol edeıyoruz.
        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
    }

    public IResult UserExists(string email)
    {
        //girilen mail sistemde varsa zaten kayıtlı dıyoruz.
        if (_userService.GetByMail(email) != null)
        {
            return new ErrorResult(Messages.UserAlreadyExists);
        }
        return new SuccesResult();
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        var claims = _userService.GetClaims(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
    }
}