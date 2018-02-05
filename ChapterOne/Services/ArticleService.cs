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
            var result = redis.KeyDelete(listkey, CommandFlags.FireAndForget);

            long result2 = redis.ListRightPush(listkey,"a");

            var len = redis.ListLength(listkey);

            result2 = redis.ListRightPush(listkey,"b");

            len = redis.ListLength(listkey);

            result = redis.KeyDelete(listkey);

            result2 = redis.ListRightPush(listkey, "abcdefghijklmnopqrstuvwxyz".Select(x => (RedisValue)x.ToString()).ToArray());

            len = redis.ListLength(listkey);

            var result3 = string.Concat(redis.ListRange(listkey));

            var lastFive = redis.ListRange(listkey,-5);

            result3 = string.Concat(lastFive);

            var firstFive = redis.ListRange(listkey,0,4);

            redis.ListTrim(listkey,0,1);

            var trimedList = redis.ListRange(listkey);

            result = redis.KeyDelete(listkey,CommandFlags.FireAndForget);

            result2 = redis.ListRightPush(listkey, "abcdefghijklmnopqrstuvwxyz".Select(x => (RedisValue)x.ToString()).ToArray());

            var firstElement = redis.ListLeftPop(listkey);

            var lastElement = redis.ListRightPop(listkey);

            long result4 = redis.ListRemove(listkey,"c");

            var removedList = string.Concat(redis.ListRange(listkey));

            //???
            redis.ListSetByIndex(listkey, 1, "c");

            var listSetByIndexed = string.Concat(redis.ListRange(listkey));

            var thirdItem = redis.ListGetByIndex(listkey,3);

            var destinationKey = "destinationList";
            result = redis.KeyDelete(listkey,CommandFlags.FireAndForget);
            result = redis.KeyDelete(listkey,CommandFlags.FireAndForget);

            result2 = redis.ListRightPush(listkey, "abcdefghijklmnopqrstuvwxyz".Select(x => (RedisValue)x.ToString()).ToArray());

            len = redis.ListLength(listkey);

            for (var i = 0; i < len; i++)
            {
                string val = redis.ListRightPopLeftPush(listkey, destinationKey);
            }


        }
    }
}