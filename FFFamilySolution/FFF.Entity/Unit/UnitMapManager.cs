using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFF.Entity.Unit
{
    public class UnitMapManager
    {
        /// <summary>
        /// 單位資料列表
        /// </summary>
        public List<Unit<Family>> UnitList { get; set; }

        
        /// <summary>
        /// 單位圖做成組織圖之樣式
        /// </summary>
        public List<Unit<Family>> OrgList { get { 
            
            return GetSubList(UnitList,"");

        } }
        
        /// <summary>
        /// 取得所有的組織的資料
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private List<Unit<Family>> GetSubList(List<Unit<Family>> list,string parent)
        {
            var topList = list.Where(p => p.ParentUnitID == parent).ToList();

            topList.ForEach(p => {

                p.ChildrenUnit=GetSubList(list,p.UnitID);
                                
            });
                        
            return topList;
        }

    }
}
