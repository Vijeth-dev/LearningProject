using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomCommonLayer.Entities;

namespace BookMyRoomAPILayer.Models
{
    public class ModelMapper
    {
        public static Update_Password ModelToEntity_Update(UserModel userRegisterModel)
        {
            return new Update_Password()
            {
                Email = userRegisterModel.Email,
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                PhoneNo = userRegisterModel.PhoneNo,
                Current_Password = userRegisterModel.Current_Password,
                Password = userRegisterModel.Password
            };
        }
        public static Update_Password ModelToEntity_Update(HotelManagerlogin hotelManagerlogin)
        {
            return new Update_Password()
            {
                Email = hotelManagerlogin.Email,
                FirstName = hotelManagerlogin.FirstName,
                PhoneNo = hotelManagerlogin.PhoneNo,
                Current_Password = hotelManagerlogin.Current_Password,
                Password = hotelManagerlogin.Password
            };
        }

        public static UserProfiles ModelToEntity(UserModel userRegisterModel)
        {
            return new UserProfiles()
            {
                User_EmailID = userRegisterModel.Email,
                User_FirstName = userRegisterModel.FirstName,
                User_Lastname = userRegisterModel.LastName,
                User_PhoneNumber = userRegisterModel.PhoneNo,
                User_Password = userRegisterModel.Password
            };
        }

        public static SearchResult ModelToEntity(HotelModel hotelModel)
        {
            return new SearchResult()
            {
                Hotel_Name = hotelModel.HotelName,
                Hotel_Address = hotelModel.HotelAddress,
                Hotel_Phone = hotelModel.HotelContact,
                Hotel_Email = hotelModel.HotelEmailID,
                Hotel_Rating = hotelModel.Rating,
                AirportDistance = Convert.ToDouble(hotelModel.AirportDistance),
                RailwayDistance = Convert.ToDouble(hotelModel.RailwayDistance),
                Wifi = hotelModel.Wifi,
                Parking = hotelModel.Parking,
                Restaurant = hotelModel.Restaurant,
                Pool = hotelModel.Pool,
                BudgetRoomCount = hotelModel.BudgetRoomCount,
                BudgetRoomPrice = hotelModel.BudgetRoomPrice,
                DeluxeRoomCount = hotelModel.DeluxeRoomCount,
                DeluxeRoomPrice = hotelModel.DeluxeRoomPrice,
                Pictures = hotelModel.Images
            };

        }

        public static LogInDetails ModelToEntity(UserLoginModel userLoginModel)
        {
            return new LogInDetails()
            {
                UserEmail = userLoginModel.Email,
                Password = userLoginModel.Password,
                Designation = userLoginModel.Designation

            };
        }

        public static UserModel EntityToModel(UserProfiles userProfiles)
        {
            if (userProfiles != null)
            {
                return new UserModel()
                {
                    UserID = userProfiles.User_ID,
                    Email = userProfiles.User_EmailID,
                    FirstName = userProfiles.User_FirstName,
                    LastName = userProfiles.User_Lastname,
                    PhoneNo = userProfiles.User_PhoneNumber
                };
            }
            return null;
        }

        public static UserModel EntityToModel(Update_Password userProfiles)
        {
            if (userProfiles != null)
            {
                return new UserModel()
                {
                    Email = userProfiles.Email,
                    FirstName = userProfiles.FirstName,
                    LastName = userProfiles.LastName,
                    Current_Password = userProfiles.Current_Password,
                    PhoneNo = userProfiles.PhoneNo
                };
            }
            return null;
        }
        public static HotelManagerlogin EntityToModelManager(Update_Password userProfiles)
        {
            if (userProfiles != null)
            {
                return new HotelManagerlogin()
                {
                    Email = userProfiles.Email,
                    FirstName = userProfiles.FirstName,
                    PhoneNo = userProfiles.PhoneNo
                };
            }
            return null;
        }

        public static HotelManagerModel EntityToModel(HotelManager hotelManager)
        {
            if (hotelManager != null)
            {
                return new HotelManagerModel()
                {
                    HotelManager_ID = hotelManager.HotelManager_ID,
                    HotelManager_Name = hotelManager.HotelManager_Name,
                    HotelManager_PhoneNumber = hotelManager.HotelManager_PhoneNumber,
                    _EmailID = hotelManager._EmailID,
                    _Password = hotelManager._Password,
                    _Designation = hotelManager._Designation,
                    _Status = hotelManager._Status
                };
            }
            return null;
        }

        public static HotelManager ModelToEntity(HotelManagerModel hotelManager)
        {
            if (hotelManager != null)
            {
                return new HotelManager()
                {
                    HotelManager_ID = hotelManager.HotelManager_ID,
                    HotelManager_Name = hotelManager.HotelManager_Name,
                    HotelManager_PhoneNumber = hotelManager.HotelManager_PhoneNumber,
                    _EmailID = hotelManager._EmailID,
                    _Password = hotelManager._Password,
                    _Designation = hotelManager._Designation,
                    _Status = hotelManager._Status
                };
            }
            return null;
        }

        public static HotelFeedback ModelToEntity(FeedbackModel hotelFeedback)
        {
            if (hotelFeedback != null)
            {
                return new HotelFeedback()
                {
                    Hotel = hotelFeedback.HotelID,
                    Title = hotelFeedback.Title,
                    Nickname = hotelFeedback.Nickname,
                    Rating = hotelFeedback.Rating,
                    Feedback = hotelFeedback.Feedback
                };
            }
            return null;
        }

        public static UserProfiles ModelToEntity(GoogleRegisterModel userModel)
        {
            if (userModel != null)
            {
                return new UserProfiles()
                {
                    User_EmailID = userModel.Email,
                    User_FirstName = userModel.FirstName,
                    User_Lastname = userModel.LastName
        };
            }
            return null;
        }

        public static SearchResult ModelToEntity(HotelAndCityNameModel hotelCity)
        {
            return new SearchResult()
            {
                Hotel_Name = hotelCity.HotelName,
                CityName = hotelCity.CityName
            };
        }

        public static BookingModel EntityToModel(BookingEntity bookingEntity)
        {
            return new BookingModel()
            {
                CheckInDate = bookingEntity.CheckInDate,
                CheckOutDate = bookingEntity.CheckOutDate,
                TotalCost = bookingEntity.TotalCost,
                NumberOfAdults = bookingEntity.NumberOfAdults,
                NumberOfInfants = bookingEntity.NumberOfInfants,
                NumberOfChildren = bookingEntity.NumberOfChildren,
                HotelID = bookingEntity.HotelID,
                UserId = bookingEntity.UserId,
                DateOfBilling = bookingEntity.DateOfBilling,
                Deluxe = bookingEntity.Deluxe,
                Premium = bookingEntity.Premium
            };
        }

        public static BookingEntity ModelToEntity(BookingModel bookingEntityModel)
        {
            return new BookingEntity()
            {
                CheckInDate = bookingEntityModel.CheckInDate,
                CheckOutDate = bookingEntityModel.CheckOutDate,
                NumberOfAdults = bookingEntityModel.NumberOfAdults,
                NumberOfChildren = bookingEntityModel.NumberOfChildren,
                NumberOfInfants = bookingEntityModel.NumberOfInfants,
                UserId = bookingEntityModel.UserId,
                DateOfBilling = bookingEntityModel.DateOfBilling,
                Deluxe = bookingEntityModel.Deluxe,
                Premium = bookingEntityModel.Premium,
                HotelID = bookingEntityModel.HotelID,
                TotalCost = bookingEntityModel.TotalCost
            };
        }

        public static List<RoomCostModel> EntityToModel(List<RoomCostEntity> roomCostEntity)
        {
            List<RoomCostModel> roomCostModel = new List<RoomCostModel>();
            RoomCostModel room = new RoomCostModel()
            {
                HotelId = roomCostEntity[0].HotelId,
                PremiumRoomCost = roomCostEntity[0].PremiumRoomCost,
                AC = roomCostEntity[0].AC,
                Geyser = roomCostEntity[0].Geyser,
                RoomService = roomCostEntity[0].RoomService,
                TV = roomCostEntity[0].TV,
                WIFI = roomCostEntity[0].WIFI
            };
            roomCostModel.Add(room);
            room = new RoomCostModel()
            {
                HotelId = roomCostEntity[1].HotelId,
                AC = roomCostEntity[1].AC,
                Geyser = roomCostEntity[1].Geyser,
                RoomService = roomCostEntity[1].RoomService,
                DeluxeRoomCost = roomCostEntity[1].DeluxeRoomCost,
                TV = roomCostEntity[1].TV,
                WIFI = roomCostEntity[1].WIFI
            };
            roomCostModel.Add(room);
            return roomCostModel;
        }

        public static RoomAvailabilityEntity ModelToEntity(RoomAvailabilityModel roomAvailabilityModel)
        {
            return new RoomAvailabilityEntity()
            {
                HotelId = roomAvailabilityModel.HotelId,
                CheckIn = roomAvailabilityModel.CheckIn,
                CheckOut = roomAvailabilityModel.Checkout,
                NumberOfDeluxeRoom = roomAvailabilityModel.NumberOfDeluxeRoom,
                NumberOfPremiumRoom = roomAvailabilityModel.NumberOfPremiumRoom
            };
        }
        public static RoomAvailabilityEntity EntityToModel(RoomAvailabilityEntity roomAvailabilityEntity)
        {
            return new RoomAvailabilityEntity()
            {
                HotelId = roomAvailabilityEntity.HotelId,
                CheckIn = roomAvailabilityEntity.CheckIn,
                CheckOut = roomAvailabilityEntity.CheckOut,
                NumberOfDeluxeRoom = roomAvailabilityEntity.NumberOfDeluxeRoom,
                NumberOfPremiumRoom = roomAvailabilityEntity.NumberOfPremiumRoom
            };
        }

        public static BookingModel EntityToModel(MyBookingsEntity bookingEntity)
        {
            return new BookingModel()
            {
                BookId = bookingEntity.BookId,
                UserId = bookingEntity.UserId,
                UserName = bookingEntity.UserName,
                Premium = bookingEntity.Premium,
                Deluxe = bookingEntity.Deluxe,
                HotelID = bookingEntity.HotelID,
                HotelName = bookingEntity.HotelName,
                DateOfBilling = bookingEntity.DateOfBilling,
                CheckInDate = bookingEntity.CheckInDate,
                CheckOutDate = bookingEntity.CheckOutDate,
                NumberOfAdults = bookingEntity.NumberOfAdults,
                NumberOfChildren = bookingEntity.NumberOfChildren,
                NumberOfInfants = bookingEntity.NumberOfInfants,
                TotalCost = bookingEntity.TotalCost,
                HotelPicture = bookingEntity.HotelPicture
            };
        }

        public static List<BookingModel> EntityToModel(List<MyBookingsEntity> bookingEntities)
        {
            List<BookingModel> bookingModels = new List<BookingModel>();
            foreach(MyBookingsEntity bookingEntity in bookingEntities)
            {
                bookingModels.Add(EntityToModel(bookingEntity));
            }

            return bookingModels;
        }
    }
}
