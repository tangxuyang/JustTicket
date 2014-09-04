using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;
using JustTicket.Logic;
using JustTicket.Net;

namespace JustTicket.Engining.Actions
{
    [Map(AliasName="DownFileAction")]
    public class RequestFileAction : Action
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        { set; get; }

        /// <summary>
        /// 请求的方式，Get或Post
        /// </summary>
        [Default(DefaultValue="Get")]
        public string Method
        { get; set; }

        /// <summary>
        /// 请求的地址
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// 请求的Body，Post使用
        /// </summary>
        [Default(DefaultValue="")]
        public string RequestBody
        { get; set; }

        /// <summary>
        /// 是否随机生成文件名
        /// </summary>
        [Default(DefaultValue="false")]
        public bool RandomFileName
        {
            get;
            set;
        }

        /// <summary>
        /// 保存后文件的全路径
        /// </summary>
        [Ignore]
        public string OutputFileName
        {
            get;
            set;
        }

        /// <summary>
        /// 如果FileName指定的文件存在是否先删除
        /// </summary>
        [Default(DefaultValue = "false")]
        public bool IsDeleteExist
        {
            get;
            set;
        }

        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            string fileName = FileName;
            if(RandomFileName)//产生随机文件名
            {
                fileName = DateTime.Now.Ticks + fileName;
            }

            if(IsDeleteExist && System.IO.File.Exists(fileName))//删除已存在同名文件
            {
                System.IO.File.Delete(fileName);
            }

            OutputFileName = NetHelper.SendRequest(Method, RequestBody, RequestBlockReturnType.FileName, Url, fileName) as string;
        }
    }
}
