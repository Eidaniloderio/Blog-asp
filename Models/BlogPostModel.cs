namespace Blog_asp.Models
{
    public class BlogPostModel
    {
        
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public string Status { get; set; }
        public DateOnly Data { get; set; }

    }
}
