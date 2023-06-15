using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSiteSolution.DATA.Enum
{
    public enum City
    {
        Вінниця = 1,
        Дніпро = 2,
        Донецьк = 3,
        Житомир = 4,
        Запоріжжя = 5,
        [Display(Name = "Івано-Франківськ")]
        Франківськ = 6,
        Київ = 7,
        Кропивницький = 8,
        Луганськ = 9,
        Луцьк = 10,
        Львів = 11,
        Маріуполь = 12,
        Миколаїв = 13,
        Одеса = 14,
        Полтава = 15,
        Рівне = 16,
        Севастополь = 17,
        Сімферополь = 18,
        Суми = 19,
        Тернопіль = 20,
        Ужгород = 21,
        Харків = 22,
        Херсон = 23,
        Хмельницький = 24,
        Черкаси = 25,
        Чернівці = 26,
        Чернігів = 27
    }
}
