using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;
namespace tranvanphuongdoan3.Bussiness
{

    public class nhanBus
    {
       nhanModel spm = new nhanModel();
        public List<nhan> LaySPham()
        {
            List<nhan> lsp = spm.LaySPham();
            return lsp;
        }
      
        public List<nhan> LaySPBanChay(int so, string ngaythang)
        {
            List<nhan> sp = spm.LaySPBanChay(so, ngaythang);
            return sp;
        }
    }
}