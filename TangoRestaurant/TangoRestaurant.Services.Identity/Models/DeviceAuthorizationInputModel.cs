// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace TangoRestaurant.Services.Identity.Models
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}