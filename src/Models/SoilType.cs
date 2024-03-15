using System.ComponentModel.DataAnnotations;

namespace VirtualGarden;

public enum SoilType
{
    [Display(Name = "Clay")]
    Clay,
    [Display(Name = "Loam")]
    Loam,
    [Display(Name = "Sand")]
    Sand,
    [Display(Name = "Silt")]
    Silt,
    [Display(Name = "Peat")]
    Peat,
    [Display(Name = "Chalk")]
    Chalk,
    [Display(Name = "Marl")]
    Marl,
    [Display(Name = "Loess")]
    Loess,
    [Display(Name = "Rocky")]
    Rocky,
    [Display(Name = "Clay Loam")]
    ClayLoam,
    [Display(Name = "Sandy Loam")]
    SandyLoam,
    [Display(Name = "Silty Loam")]
    SiltyLoam,
    [Display(Name = "Peaty Loam")]
    PeatyLoam,
    [Display(Name = "Sandy Clay Loam")]
    SandyClayLoam,
    [Display(Name = "Silty Clay Loam")]
    SiltyClayLoam,
    [Display(Name = "Loamy Sand")]
    LoamySand,
    [Display(Name = "Silty Clay")]
    SiltyClay,
    [Display(Name = "Peat Silt")] 
    PeatSilt,
    [Display(Name = "Peat Clay")]
    PeatClay,
    [Display(Name = "Rocky Sand")]
    RockySandy,
    [Display(Name = "Rocky Loam")]
    RockyLoam,
    [Display(Name = "Rocky Clay")]
    RockyClay
}
