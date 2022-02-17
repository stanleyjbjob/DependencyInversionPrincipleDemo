using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ITransCardService _transCardService;

        public AttendanceController(ITransCardService transCardService)
        {
            _transCardService = transCardService;
        }
        [HttpGet("TransCard")]
        public string TransCard()
        {
            return _transCardService.Run();
        }
    }
    public class TransCardService : ITransCardService
    {
        public string Run()
        {
            string result = "";
            result += "讀取資料" + Environment.NewLine;
            result += "判斷刷卡" + Environment.NewLine;
            result += "判斷異常" + Environment.NewLine;
            result += "回寫資料" + Environment.NewLine;
            return result;
        }
    }
    /*
    模組拆開
    先寫抽象類別可以模擬物件的操作是否合理
    撰寫實作時則可以分工撰寫
     */
    public class AggregateTranscardService : ITransCardService
    {
        private readonly ITransCardModule _transCardModule;
        
        public AggregateTranscardService(ITransCardModule transCardModule)
        {
            _transCardModule = transCardModule;
        }
        public string Run()
        {
            //SRP
            string data = _transCardModule.GetData();
            string attcardData = _transCardModule.TransAttCard(data);
            string attendErrorData = _transCardModule.CheckError(attcardData);
            string saveData= _transCardModule.SaveData(data, attcardData, attendErrorData);

            return data + attcardData + attendErrorData + saveData;
        }
    }
    public class AggregateTransCardModule : ITransCardModule
    {
        public string CheckError(object attcardData)
        {
           return "判斷異常" + Environment.NewLine;
        }

        public string GetData()
        {
          return "讀取資料" + Environment.NewLine;
        }

        public string SaveData(object data, object attcardData, object attendErrorData)
        {
            return "回寫資料" + Environment.NewLine;
        }

        public string TransAttCard(object data)
        {
            return "判斷刷卡" + Environment.NewLine;
        }
    }

    public class AggregateTranscardServiceWithoutSave : ITransCardService
    {
        private readonly ITransCardModule _transCardModule;

        public AggregateTranscardServiceWithoutSave(ITransCardModule transCardModule)
        {
            _transCardModule = transCardModule;
        }
        public string Run()
        {
            //SRP
            string data = _transCardModule.GetData();
            string attcardData = _transCardModule.TransAttCard(data);
            string attendErrorData = _transCardModule.CheckError(attcardData);
            //string saveData = _transCardModule.SaveData(data, attcardData, attendErrorData);

            return data + attcardData + attendErrorData;
        }
    }
}
