using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    public delegate void ArticleProcess(Article article);

    class ArticleProcessor
    {
        private readonly IList<ArticleProcess> prePublication;
        private readonly IList<ArticleProcess> cameraReady;

        public void AddPrePublicationProcess(ArticleProcess process)
        {
            prePublication.Add(process);
        }

        public void PrePublish(Article article)
        {
            foreach (var process in prePublication)
            {
                process(article);
            }
        }
    }

    public class Article
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public ArticleType Type { get; set; }
    }

    public enum ArticleType { Article, Advertisement }

    class ArticleProcessor2
    {
        protected readonly IList<Action<Article>> prePublication;
        protected readonly IList<Action<Article>> cameraReady;

        public void AddPrePublicationProcess(Action<Article> process)
        {
            prePublication.Add(process);
        }

        public void PrePublish(Article article)
        {
            foreach (var process in prePublication)
            {
                process(article);
            }
        }
    }
}
