using LoanSystem;
using Microsoft.EntityFrameworkCore;


// Inicializando um conjunto de parâmetros que serão utilizados
// para realizar a criação do contexto com o banco dados
var contextOptions = new DbContextOptionsBuilder<CustomDbContext>()
    .UseNpgsql("User ID=root;Password=rafa123;Host=localhost;Port=5432;Database=entitystudy;")
    .Options;

