using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace API.Models.Entities
{
    [JsonConverter(typeof(CustomStringToEnumConverter<Genre>))]
    public enum Genre
    {
        [EnumMember(Value = "Romance")]
        Romance,

        [EnumMember(Value = "Mystery")]
        Mystery,
        
        [EnumMember(Value = "Historical")]
        Historical,

        [EnumMember(Value = "NonFiction")]
        NonFiction,

        [EnumMember(Value = "Fantasy")]
        Fantasy,

        [EnumMember(Value = "Horror")]
        Horror,
    }

    public class CustomStringToEnumConverter<T> : StringEnumConverter
{
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (string.IsNullOrEmpty(reader.Value?.ToString()))
        {
            return null;
        }
        try
        {
            return EnumExtensions.GetValueFromEnumMember<T>(reader.Value.ToString());
        }
        catch (Exception)
        {
            return null;
        }
    }
}

public static class EnumExtensions
{
    public static T GetValueFromEnumMember<T>(string value)
    {
        var type = typeof(T);
        if (!type.IsEnum) throw new InvalidOperationException();
        foreach (var field in type.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field,
                typeof(EnumMemberAttribute)) as EnumMemberAttribute;
            if (attribute != null)
            {
                if (attribute.Value == value)
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == value)
                    return (T)field.GetValue(null);
            }
        }
        throw new ArgumentException($"unknow value: {value}");
    }
}
}