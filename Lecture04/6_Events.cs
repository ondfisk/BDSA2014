using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    public delegate void ArticleEventHandler(object sender, ProcessEventArgs e);

    public class ArticleProcessor8
    {
        protected readonly IList<Tuple<Action<Article>, Predicate<Article>>> prePublication;

        public event EventHandler PrePublication;
        
        // public event ArticleEventHandler PrePublication;

        public void AddPrePublicationProcess(Action<Article> process, Predicate<Article> check)
        {
            prePublication.Add(Tuple.Create(process, check));
        }

        public void PrePublish(Article article)
        {
            if (PrePublication != null)
            {
                PrePublication.Invoke(this, new EventArgs());
                
                PrePublication(this, EventArgs.Empty);
            }

            foreach (var process in prePublication)
            {
                if (process.Item2 == null || process.Item2(article))
                {
                    process.Item1(article);
                }
            }
        }
    }

    class ProcessingLog
    {
        protected void OnPreProcessing(object sender, EventArgs e)
        {
            Console.WriteLine("An article is pre-processing");
        }

        //protected void OnPreProcessing(object sender, ProcessEventArgs e)
        //{
        //    Console.WriteLine(e.Article.Title + " is pre-processing");
        //}

        public void Subscribe(ArticleProcessor8 articleProcessor)
        {
            // Event subscription - always +=, never =.
            articleProcessor.PrePublication += OnPreProcessing;
        }

        public void Unsubscribe(ArticleProcessor8 articleProcessor)
        {
            // Event unsubscription - always -=, never = null.
            articleProcessor.PrePublication -= OnPreProcessing;
        }
    }

    public class Stuff
    {
        void MainStuff(string[] args)
        {
            var articleProcessor = new ArticleProcessor8();
            articleProcessor.PrePublication += (sender, e) => Console.WriteLine("An article is pre-processing");
            articleProcessor.PrePublication += (sender, e) => { if (e != null) { Console.WriteLine("eeee!"); } };
        }
    }

    public class ProcessEventArgs : EventArgs
    {   
        public Article Article { get; protected set; }

        public ProcessEventArgs(Article article)
        {
            Article = article;
        }
    }
}
