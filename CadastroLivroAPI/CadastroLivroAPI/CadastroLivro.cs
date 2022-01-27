namespace CadastroLivroAPI
{
    public class CadastroLivro
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
    }
}
