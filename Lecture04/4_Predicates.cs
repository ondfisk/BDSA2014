using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    public delegate bool Checker(Article article);

    class ArticleProcessor3
    {
        protected readonly IList<Action<Article>> prePublication;
        protected readonly IList<Checker> checkPublication;
        protected readonly IList<Action<Article>> postPublication;

        public bool Check(Article article)
        {
            foreach (var check in checkPublication)
            {
                if (!check(article))
                {
                    return false;
                }
            }

            return true;
        }
    }

    class ArticleProcessor4
    {
        protected readonly IList<Action<Article>> prePublication;
        protected readonly IList<Predicate<Article>> checkPublication;
        protected readonly IList<Action<Article>> postPublication;
    }

    class ArticleProcessor5
    {
        private struct Process
        {
            public Predicate<Article> Check { get; set; }
            public Action<Article> Action { get; set; }
        }

        private readonly IList<Process> prePublication;

        public void AddPrePublicationProcess(Action<Article> action, Predicate<Article> check)
        {
            prePublication.Add(new Process { Action = action, Check = check });
        }

        public void PrePublish(Article article)
        {
            foreach (var item in prePublication)
            {
                if (item.Check == null || item.Check(article))
                {
                    item.Action(article);
                }
            }
        }
    }

    class ArticleProcessor6
    {
        private readonly IList<Tuple<Action<Article>, Predicate<Article>>> prePublication;

        public void AddPrePublicationProcess(Action<Article> process, Predicate<Article> check)
        {
            prePublication.Add(Tuple.Create(process, check));
        }

        public void PrePublish(Article article)
        {
            foreach (var process in prePublication)
            {
                if (process.Item2 == null || process.Item2(article))
                {
                    process.Item1(article);
                }
            }
        }
    }
}

