﻿/*==============================
 * Copyright(c) Coalition of Good-Hearted Engineers
 * Free to Use To Find Comfort and Peace
 =================================*/

using System;
using Sheenam.Api.Models.Foundations.Guests;
using System.Threading.Tasks;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Brokers.Loggings;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            return await this.storageBroker.InsertGuestAsync(guest);
        }       
        
    }
}
