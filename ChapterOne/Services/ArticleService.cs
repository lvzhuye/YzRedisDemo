using ChapterOne.Infrastructure;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChapterOne.Services
{
    public class ArticleService:IArticleService
    {
        private IDatabase redis;

        public ArticleService()
        {
            redis = RedisStore.Instance.RedisCache;
        }

        public void CreateArticle(Models.ViewModels.CreateArticleVm createArticleVm)
        {
            //生成新的文章Id

            //if (redis.StringSet("testkey", "testValue"))
            //{
            //    string val = redis.StringGet("testkey");
            //}

            //string val2 = redis.StringGetSet("testkey","testValue2");

            //string val3 = redis.StringGet("testkey");

            //bool result = redis.StringSet("testkey","testValue3");

            

            //result = redis.KeyDelete("testkey");

            //result = redis.KeyDelete("testkey");

            //string val4 = redis.StringGet("testkey");

            var listkey = "listkey";
            redis.KeyDelete(listkey,CommandFlags.FireAndForget);

            var result = redis.ListRightPush(listkey,"a");

            var len = redis.ListLength(listkey);

            result = redis.ListRightPush(listkey,"b");

            len = redis.ListLength(listkey);

            
        }
    }
}