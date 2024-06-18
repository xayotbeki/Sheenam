using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Api.Models.Foundations.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldAddGuestAsync1()
        {
            //given
            Guest randomGuest = new Guest
            {
                Id = Guid.NewGuid(),
                FirstName = "Alex",
                LastName = "Doe",
                Address = "Brooks Str. #12",
                DateOdBirth = new DateTimeOffset(),
                Email = "random@mail.ru",
                Gender = GenderType.Male,
                PhoneNumber = "123456",
            };
            Guest inputGuest = randomGuest;
            Guest storageGuest = inputGuest;
            Guest expectedGuest = storageGuest.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGuestAsync(inputGuest))
                    .ReturnsAsync(storageGuest);

            //when
            Guest actualGuest = 
                await this.guestService.AddGuestAsync(inputGuest);

            //then
            actualGuest.Should().BeEquivalentTo(expectedGuest);

            this.storageBrokerMock.Verify(broker => 
                broker.InsertGuestAsync(inputGuest),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
