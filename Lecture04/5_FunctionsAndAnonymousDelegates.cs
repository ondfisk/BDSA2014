using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    public delegate string LogInfo(Article article);

    class ArticleProcessor7
    {
        public Func<Article, string> LogInfo { get; set; }

        public ArticleProcessor7()
        {
            LogInfo = SimpleArticleInfo;
            LogInfo = FullArticleInfo;

            #region Anonymous
            LogInfo = delegate(Article article)
                      {
                          return article.Title;
                      };

            LogInfo = delegate(Article article)
            {
                return article.Type == ArticleType.Advertisement ? 
                                       article.Title : 
                                       string.Format("{0} by {1}", article.Title, article.Author);
            };
            #endregion

            #region Lambda
            // Lambda here...
            LogInfo = a => a.Title;

            LogInfo = article =>
            {
                if (article.Type == ArticleType.Advertisement)
                {
                    return article.Title;
                }
                else
                {
                    return string.Format("{0} by {1}", article.Title, article.Author);
                }
            };

            Func<int, bool> evenFunc = x => x % 2 == 0;

            var list = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> evens = list.Where(evenFunc);

            #endregion
        }

        public string SimpleArticleInfo(Article article)
        {
            return article.Title;
        }

        public string FullArticleInfo(Article article)
        {
            if (article.Type == ArticleType.Advertisement)
            {
                return article.Title;
            }
            else
            {
                return string.Format("{0} by {1}", article.Title, article.Author);
            }
        }
    }
}
