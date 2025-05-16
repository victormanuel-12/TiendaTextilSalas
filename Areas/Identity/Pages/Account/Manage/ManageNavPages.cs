// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace proyectoTienda.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string Nombre => "Nombre";
        public static string Direccion => "Direccion";
        public static string Dni => "Dni";
        public static string Numero => "Numero";
        public static string Email => "Email";
        public static string ChangePassword => "ChangePassword";
        public static string DownloadPersonalData => "DownloadPersonalData";
        public static string DeletePersonalData => "DeletePersonalData";
        public static string ExternalLogins => "ExternalLogins";
        public static string PersonalData => "PersonalData";
        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string IndexNavClass(ViewContext vc) => PageNavClass(vc, Index);
        public static string NombreNavClass(ViewContext vc) => PageNavClass(vc, Nombre);
        public static string DireccionNavClass(ViewContext vc) => PageNavClass(vc, Direccion);
        public static string DniNavClass(ViewContext vc) => PageNavClass(vc, Dni);
        public static string NumeroNavClass(ViewContext vc) => PageNavClass(vc, Numero);
        public static string EmailNavClass(ViewContext vc) => PageNavClass(vc, Email);
        public static string ChangePasswordNavClass(ViewContext vc) => PageNavClass(vc, ChangePassword);
        public static string DownloadPersonalDataNavClass(ViewContext vc) => PageNavClass(vc, DownloadPersonalData);
        public static string DeletePersonalDataNavClass(ViewContext vc) => PageNavClass(vc, DeletePersonalData);
        public static string ExternalLoginsNavClass(ViewContext vc) => PageNavClass(vc, ExternalLogins);
        public static string PersonalDataNavClass(ViewContext vc) => PageNavClass(vc, PersonalData);
        public static string TwoFactorAuthenticationNavClass(ViewContext vc) => PageNavClass(vc, TwoFactorAuthentication);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
