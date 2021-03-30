using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Jwt;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        //Bu yapı bizim wepaıp'de bulunana appsetting dosyasının ıcını okumamızı saglıyor
        public IConfiguration Configuration { get; }
        //Burası ise bizim olusturdugumuz nesne bu nesne içindeki özelliklerin aynısı appsettingde olmalı ıconfıgurate ıle okudugumuz 
        //bilgileri bu nesnedeki özelliklere atayacagız.
        private TokenOptions _tokenOptions;
        //burası ise accesstoken ne zaman geçersizleşecek.
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //aşağıdaki kod yardımı ile appsetting'de AccessTokenExpiration": 10 olarak verdiğimiz dakikayı almaması sağlıyor.
            //Iconfiguration bizim appsetting içindeki (getsection=bölümü al hangi bölüm "TokenOptions" adındaki. daha sonra 
            //bu bilgileri al TokenOptions sınıfındaki özelliklere eşle)bilgileri okumamıza yarıyor. 
            //Tabi öncesinde yukarıdaki gibi tanımlayıp constructora enjekte etmemiz gerek.
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        //IToken'daki metodumuz
        //Kullanıcımız ıcın bir adet token olusturugumuz metot bizden bir user ve bir clim istiyor ona gore olusturacagız.
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //burası tokenımıza süre veriyor. şimdidden itibaren dakıka ekle diyoruz. ne kadar dakika? appsetting, tokenoptions da accesstokenexpiration'a verdiğimiz süre kadar.
            //Bu değişken uzerinden süreyi nasıl alıyor? configuration sayaesinde. Burası=> ( _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();)
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //aynı sekıılde securitykey e de appsettingdeki securityi alıp securitykeyhelper a atıp onun asımetrık halını almamız gerek
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //burada ise yukarıdaki securitykeyi al simetrik halini onu sha5512 algoritmesına donustur diyor.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //burada ise imzadaki 4 bilgiyi alarak token uretecegız.(metot aşağıda)
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            //Token oluşturmaya yarayacak bılgıler
            //Appsettingdeki bilgileri alıyor
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                //bu claimler için aşağıda bir metot var.
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            //Buraya operatıons claım ı gonderıp onun ıcınden sadece namelerı alıp dızıne donusturuyoruz.
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}