using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActorsRazorPage.Models
{
    public interface IData
    {
        List<Actor> ActorsList { get; set; }
        List<Actor> ActorsInitializeData();
        Actor GetActorById(int? id);
    }
}
