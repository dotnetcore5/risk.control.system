﻿namespace risk.control.system.Models.ViewModel
{
    public class VendorUserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public long VendorId { get; set; }
        public string Vendor { get; set; }
        public List<VendorUserRoleViewModel> VendorUserRoleViewModel { get; set; }
    }

    public class VendorUserRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}