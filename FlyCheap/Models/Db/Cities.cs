﻿using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;

namespace FlyCheap.Models.Db;

public class Cities : NamedEntity
{
    public string country_code { get; set; }
    public string code { get; set; }
    public string time_zone { get; set; }
    public Coordinates coordinates { get; set; }
    public NameTranslations name_translations { get; set; }
    public Cases cases { get; set; }
}