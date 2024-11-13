using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System.Text;
using EnergyTech_NET.DTOs;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseApiKey;

        public AuthRepository(IConfiguration configuration, HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient(); // Usa o HttpClient fornecido ou cria um novo
            _firebaseApiKey = configuration["Firebase:ApiKey"];

            // Configurar Firebase usando o arquivo de credenciais
            if (FirebaseApp.DefaultInstance == null && File.Exists("firebase-credentials.json"))
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile("firebase-credentials.json")
                });
            }
        }

        public async Task<string> RegisterUserAsync(RegisterDTO registerDto)
        {
            var userRecordArgs = new UserRecordArgs
            {
                Email = registerDto.Email,
                Password = registerDto.Senha,
                EmailVerified = false,
                Disabled = false
            };

            var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userRecordArgs);
            return userRecord.Uid;
        }

        public async Task<string> LoginUserAsync(LoginDTO loginDto)
        {
            var credentials = new
            {
                email = loginDto.Email,
                password = loginDto.Senha,
                returnSecureToken = true
            };

            var firebaseApiKey = _firebaseApiKey; 
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={firebaseApiKey}";

            var response = await _httpClient.PostAsJsonAsync(url, credentials);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao autenticar o usuário: " + await response.Content.ReadAsStringAsync());
            }

            var authFirebaseObject = await response.Content.ReadFromJsonAsync<FirebaseLoginResponse>();

            return authFirebaseObject!.IdToken!;
        }
    }
}
