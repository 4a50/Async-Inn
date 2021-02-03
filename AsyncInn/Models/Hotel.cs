﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
  public class Hotel
  {

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }    
    public string StreetAddress { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }    
    public string Country { get; set; }
    [Required]
    public string Phone { get; set; }

    //Navigation 
    public List<HotelRoom> HotelRoom { get; set; }
    
  }
}
