using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.BL
{
    public interface IResult
    {
        /// <summary>
        /// 
        /// </summary>
        ResultStatusEnum ResultStatus { get; set; }
    }
}
