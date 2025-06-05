using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Identity;

namespace LumenSolar.WebAPI.Data
{
    public static class MocksDoador
    {
        public static readonly List<DoadorUser> Doadores =
        [
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "joao.silva@exemplo.com",
                    UserName = "joao.silva",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("João Silva", "11999999999", "12345678901", ""), // Físico
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(100, DateTime.UtcNow.AddDays(-10), 0),
                        new Doacao(150, DateTime.UtcNow.AddDays(-5), 0)
                    }
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "maria.oliveira@exemplo.com",
                    UserName = "maria.oliveira",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Maria Oliveira", "11888888888", "23456789012", ""), // Físico
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(75, DateTime.UtcNow.AddDays(-7), 0)
                    }
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "doe.mais@ajudabem.org",
                    UserName = "doe.mais",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Doe Mais ONG", "11333333333", "Doe Mais Organização", "12345678000100", ""), // Jurídico
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(500, DateTime.UtcNow.AddDays(-20), 0)
                    }
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "ana.lima@exemplo.com",
                    UserName = "ana.lima",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Ana Lima", "11666666666", "34567890123", ""), // Físico
                    Doacoes = new List<Doacao>()
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "ajude.ja@beneficia.org",
                    UserName = "ajude.ja",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Ajude Já", "11222222222", "Ajude Já Fundação", "99887766000155", ""), // Jurídico
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(1000, DateTime.UtcNow.AddDays(-40), 0),
                        new Doacao(850, DateTime.UtcNow.AddDays(-15), 0)
                    }
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "lucia.almeida@exemplo.com",
                    UserName = "lucia.almeida",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Lucia Almeida", "11444444444", "45678901234", ""), // Físico
                    Doacoes = new List<Doacao>()
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "ricardo.fernandes@exemplo.com",
                    UserName = "ricardo.fernandes",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Ricardo Fernandes", "11777777777", "56789012345", ""), // Físico
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(180, DateTime.UtcNow.AddDays(-18), 0)
                    }
                }
            },
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
                    Doador = new Doador("Global Solidária", "1177770000", "Global Solidária Ltda", "55443322000199", ""), // Jurídico
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
                    Doador = new Doador("Camila Teixeira", "11000000000", "67890123456", ""), // Físico
                    Doacoes = new List<Doacao>
                    {
                        new Doacao(200, DateTime.UtcNow.AddDays(-3), 0)
                    }
                }
            },
            new DoadorUser
            {
                User = new IdentityUser
                {
                    Email = "sara.gomes@exemplo.com",
                    UserName = "sara.gomes",
                    EmailConfirmed = true
                },
                Doador = new DoadorDoacao
                {
                    Doador = new Doador("Sara Gomes", "11911111111", "78901234567", ""), // Físico
                    Doacoes = new List<Doacao>()
                }
            }
        ];
    }

    public static class MocksFamilia
    {
        public static readonly List<FamiliaUser> Familias =
        [
            new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "joana.silva@exemplo.com",
                UserName = "joana.silva",
                EmailConfirmed = true
            },
            Familia = new Familia(
                nomeResponsavel: "Joana Silva",
                cpf: "12345678900",
                celular: "11999990000",
                rendaFamiliar: 1500,
                numeroMoradores: 4,
                gastoComEnergia: 200,
                situacaoVulnerabilidade: "Desemprego",
                endereco: new FamiliaEndereco("01001-000", "Rua A", 100, "Centro", "São Paulo", "SP"),
                userId: ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "carlos.pereira@exemplo.com",
                UserName = "carlos.pereira",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Carlos Pereira",
                "23456789011",
                "11888887777",
                2500,
                5,
                320,
                "Saúde precária",
                new FamiliaEndereco("01311-000", "Rua B", 250, "Bela Vista", "São Paulo", "SP"),
                ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "ana.moura@exemplo.com",
                UserName = "ana.moura",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Ana Moura",
                "34567890122",
                "11777776666",
                1800,
                3,
                180,
                "Mãe solo",
                new FamiliaEndereco("02020-020", "Rua C", 45, "Santana", "São Paulo", "SP"),
                ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "paulo.costa@exemplo.com",
                UserName = "paulo.costa",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Paulo Costa",
                "45678901233",
                "11666665555",
                1200,
                6,
                250,
                "Baixa escolaridade",
                new FamiliaEndereco("03030-030", "Rua D", 12, "Mooca", "São Paulo", "SP"),
                ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "marcia.nunes@exemplo.com",
                UserName = "marcia.nunes",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Márcia Nunes",
                "56789012344",
                "11555554444",
                2000,
                4,
                300,
                "Idosos na família",
                new FamiliaEndereco("04040-040", "Rua E", 500, "Vila Mariana", "São Paulo", "SP"),
                ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "daniel.almeida@exemplo.com",
                UserName = "daniel.almeida",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Daniel Almeida",
                "67890123455",
                "11444443333",
                900,
                2,
                100,
                "Dependente químico",
                new FamiliaEndereco("05050-050", "Rua F", 321, "Lapa", "São Paulo", "SP"),
                ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "elisa.santos@exemplo.com",
                UserName = "elisa.santos",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Elisa Santos",
                "78901234566",
                "11333332222",
                1100,
                5,
                180,
                "Moradia precária",
                new FamiliaEndereco("06060-060", "Rua G", 78, "Osasco", "Osasco", "SP"),
                ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "roberto.teixeira@exemplo.com",
                UserName = "roberto.teixeira",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Roberto Teixeira",
                "89012345677",
                "11222221111",
                1750,
                4,
                210,
                "Violência doméstica",
                new FamiliaEndereco("07070-070", "Rua H", 99, "Guarulhos", "Guarulhos", "SP"),
                ""
            )
        },
        new FamiliaUser
        {
            User = new IdentityUser
            {
                Email = "silvia.gomes@exemplo.com",
                UserName = "silvia.gomes",
                EmailConfirmed = true
            },
            Familia = new Familia(
                "Silvia Gomes",
                "90123456788",
                "11111110000",
                1600,
                3,
                190,
                "Filhos pequenos",
                new FamiliaEndereco("08080-080", "Rua I", 111, "Itaquera", "São Paulo", "SP"),
                ""
            )
        },
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
        ];
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
