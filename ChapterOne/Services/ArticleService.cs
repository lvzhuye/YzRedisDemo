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

            //var listkey = "listkey";
            //var result = redis.KeyDelete(listkey, CommandFlags.FireAndForget);

            //long result2 = redis.ListRightPush(listkey,"a");

            //var len = redis.ListLength(listkey);

            //result2 = redis.ListRightPush(listkey,"b");

            //len = redis.ListLength(listkey);

            //result = redis.KeyDelete(listkey);

            //result2 = redis.ListRightPush(listkey, "abcdefghijklmnopqrstuvwxyz".Select(x => (RedisValue)x.ToString()).ToArray());

            //len = redis.ListLength(listkey);

            //var result3 = string.Concat(redis.ListRange(listkey));

            //var lastFive = redis.ListRange(listkey,-5);

            //result3 = string.Concat(lastFive);

            //var firstFive = redis.ListRange(listkey,0,4);

            //redis.ListTrim(listkey,0,1);

            //var trimedList = redis.ListRange(listkey);

            //result = redis.KeyDelete(listkey,CommandFlags.FireAndForget);

            //result2 = redis.ListRightPush(listkey, "abcdefghijklmnopqrstuvwxyz".Select(x => (RedisValue)x.ToString()).ToArray());

            //var firstElement = redis.ListLeftPop(listkey);

            //var lastElement = redis.ListRightPop(listkey);

            //long result4 = redis.ListRemove(listkey,"c");

            //var removedList = string.Concat(redis.ListRange(listkey));

            ////???
            //redis.ListSetByIndex(listkey, 1, "c");

            //var listSetByIndexed = string.Concat(redis.ListRange(listkey));

            //var thirdItem = redis.ListGetByIndex(listkey,3);

            //var destinationKey = "destinationList";
            //result = redis.KeyDelete(listkey,CommandFlags.FireAndForget);
            //result = redis.KeyDelete(listkey,CommandFlags.FireAndForget);

            //result2 = redis.ListRightPush(listkey, "abcdefghijklmnopqrstuvwxyz".Select(x => (RedisValue)x.ToString()).ToArray());

            //len = redis.ListLength(listkey);

            //for (var i = 0; i < len; i++)
            //{
            //    string val = redis.ListRightPopLeftPush(listkey, destinationKey);
            //}

            RedisKey key = "setkey";
            RedisKey alphakey = "alphakey";
            RedisKey numkey = "numberkey";
            RedisKey destinationkey = "destkey";

            var result = redis.KeyDelete(key, CommandFlags.FireAndForget);
            result = redis.KeyDelete(alphakey, CommandFlags.FireAndForget);
            result = redis.KeyDelete(numkey, CommandFlags.FireAndForget);
            result = redis.KeyDelete(destinationkey, CommandFlags.FireAndForget);

            for (int i = 1; i <= 10; i++)
            {
                result = redis.SetAdd(key,i);
            }

            result = redis.SetAdd(key,1);

            var members = redis.SetMembers(key);

            var result2 = string.Join(",", members);

            result = redis.SetContains(key, 10);

            var len = redis.SetLength(key);

            redis.SetAdd(alphakey, "abc".Select(x => (RedisValue)x.ToString()).ToArray());
            redis.SetAdd(numkey, "123".Select(x => (RedisValue)x.ToString()).ToArray());

            //redis.SetAdd(alphakey,"1");

            //var result6 = redis.SetMembers(alphakey);

            var values = redis.SetCombine(SetOperation.Union,numkey,alphakey);

            var result3 = string.Join(",",values);

            values = redis.SetCombine(SetOperation.Difference, key, numkey);

            var result4 = string.Join(",",values);

            values = redis.SetCombine(SetOperation.Intersect,key,numkey);

            var result5 = string.Join(",",values);

            //??
            var result6 = redis.SetMove(numkey,alphakey,2);

            var result7 = redis.SetMembers(numkey);

            var result8 = redis.SetMembers(alphakey);

            redis.SetAdd(alphakey,"apple");

            var result9 = redis.SetScan(alphakey,"ap*");

            var result10 = string.Join(",",result9);

            var result11 = redis.SetScan(alphakey,"a*");

            var result12 = string.Join(",",result11);

            redis.SetCombineAndStore(SetOperation.Union, destinationkey, numkey, alphakey);

            var result13 = redis.SetMembers(destinationkey);

            //???
            var result14 = redis.SetPop(numkey);

            var result15 = redis.SetMembers(numkey);





        }
    }
}