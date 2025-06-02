using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Identity;

namespace LumenSolar.WebAPI.Data
{
    public static class MocksDoador
    {
        public static readonly List<DoadorUser> Doadores = new()
        {
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "global.solidaria@solidariedade.org",
                    UserName = "global.solidaria",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Global Solidária", "1177770000", "Global Solidária Ltda", "55443322000199", ""),
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(1200, DateTime.UtcNow.AddDays(-90), 0)
                    }
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "camila.teixeira@exemplo.com",
                    UserName = "camila.teixeira",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Camila Teixeira", "11000000000", "67890123456", ""),
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(200, DateTime.UtcNow.AddDays(-3), 0)
                    }
                }
            }
        };
    }

    public static class MocksFamilia
    {
        public static readonly List<FamiliaUser> Familias = new()
        {
            new FamiliaUser
            {
                User = new IdentityUser
                {
                    Email = "marcelo.lopes@exemplo.com",
                    UserName = "marcelo.lopes",
                    EmailConfirmed = true
                },
                Familia = new Familia(
                    "Marcelo Lopes",
                    "01234567899",
                    "11987654321",
                    2100,
                    6,
                    280,
                    "Trabalho informal",
                    new FamiliaEndereco("09090-090", "Rua J", 222, "São Mateus", "São Paulo", "SP"),
                    ""
                )
            }
        };
    }

    public class DoadorDoacao
    {
        public Doador Doador { get; set; }
        public List<Doacao> Doacoes { get; set; }
    }

    public class DoadorUser
    {
        public IdentityUser User { get; set; }
        public DoadorDoacao Doador { get; set; }
    }

    public class FamiliaUser
    {
        public IdentityUser User { get; set; }
        public Familia Familia { get; set; }
    }

    public class SeedService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Context _context;

        public SeedService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            Context context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedAsync()
        {
            // _context.Database.EnsureDeleted();
            // _context.Database.EnsureCreated();

            string roleDoador = "doador";
            string roleFamilia = "familia";
            string roleAdmin = "admin";

            foreach (string role in new[] { roleDoador, roleFamilia, roleAdmin })
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string adminEmail = "admin@admin.com";
            string adminSenha = "admin1234";

            if (!_userManager.Users.Any(x => x.Email == adminEmail))
            {
                IdentityUser user = new()
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                };

                IdentityResult userResult = await _userManager.CreateAsync(user, adminSenha);
                if (!userResult.Succeeded)
                {
                    foreach (var error in userResult.Errors)
                        Console.WriteLine($"Erro ao criar usuário {user.Email}: {error.Description}");
                }

                await _userManager.AddToRoleAsync(user, roleAdmin);
            }

            foreach (DoadorUser mock in MocksDoador.Doadores)
            {
                IdentityUser user = mock.User;
                string senhaPadrao = "Senha123!";

                IdentityResult userResult = await _userManager.CreateAsync(user, senhaPadrao);
                if (!userResult.Succeeded)
                {
                    foreach (var error in userResult.Errors)
                        Console.WriteLine($"Erro ao criar usuário {user.Email}: {error.Description}");

                    continue;
                }

                await _userManager.AddToRoleAsync(user, roleDoador);

                mock.Doador.Doador.UserId = user.Id;

                _context.Doador.Add(mock.Doador.Doador);
                await _context.SaveChangesAsync();

                int doadorId = mock.Doador.Doador.Id;

                foreach (Doacao doacao in mock.Doador.Doacoes)
                {
                    _context.Doacao.Add(new Doacao(doacao.Valor, doacao.Data, doadorId));
                }

                await _context.SaveChangesAsync();
            }

            foreach (FamiliaUser mock in MocksFamilia.Familias)
            {
                IdentityUser user = mock.User;
                string senhaPadrao = "Senha123!";

                IdentityResult userResult = await _userManager.CreateAsync(user, senhaPadrao);
                if (!userResult.Succeeded)
                {
                    foreach (var error in userResult.Errors)
                        Console.WriteLine($"Erro ao criar usuário {user.Email}: {error.Description}");

                    continue;
                }

                await _userManager.AddToRoleAsync(user, roleFamilia);

                mock.Familia.UserId = user.Id;

                _context.FamiliaEndereco.Add(mock.Familia.Endereco);
                await _context.SaveChangesAsync();

                mock.Familia.EnderecoId = mock.Familia.Endereco.Id;

                _context.Familia.Add(mock.Familia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
