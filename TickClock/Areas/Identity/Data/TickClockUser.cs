using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson.Serialization.Attributes;

namespace TickClock.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TickClockUser class
    [BsonIgnoreExtraElements]
    public class TickClockUser : MongoUser
    {
        //[PersonalData]
        public string FirstName { get; set; }

        //[PersonalData]
        public string LastName { get; set; }
    }
}
