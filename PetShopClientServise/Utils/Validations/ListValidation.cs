﻿namespace PetShopClientServise.Utils.Validations;

public class ListValidation
{
    public static bool ListNotEmpty<T>(List<T> values) => values.Count > 0;
}
