using lab5.Models;
using lab5.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab5.Services.Business {
    public class SecurityService {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user) {
            return daoService.FindByUser(user);
        }
    }
}