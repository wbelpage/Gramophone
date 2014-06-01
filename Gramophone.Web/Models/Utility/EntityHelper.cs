using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;

namespace Gramophone.Web.Models.Utility
{
    public static class EntityHelper
    {
        public static TEntity CreateEntityFromDataRow<TEntity>(DataRow drData)
            where TEntity : class, new()
        {
            Attribute aTargetAttribute;
            Type tColumnDataType;

            TEntity targetClass = new TEntity();
            Type targetType = targetClass.GetType(); // The target object's type

            PropertyInfo[] properties = targetType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            // Enumerate the properties and each property which has the XmlElementAttribute defined match the column name
            // and set the new objects value..
            foreach (PropertyInfo piTargetProperty in properties)
            {
                aTargetAttribute = Attribute.GetCustomAttribute(piTargetProperty, typeof(XmlElementAttribute));

                if (aTargetAttribute != null)
                {
                    try
                    {
                        foreach (DataColumn column in drData.Table.Columns)
                        {
                            if (((XmlElementAttribute)aTargetAttribute).ElementName.ToUpper() == column.ColumnName.ToUpper())
                            {
                                if (drData[column.ToString()] != DBNull.Value) // Only pull over actual values
                                {
                                    tColumnDataType = drData[column.ToString()].GetType();
                                    // Is the data in the database  a string format and do we
                                    // want a DateTime? Do the below checks and if so covert to datetime.
                                    if ((tColumnDataType != null) &&
                                        (tColumnDataType == typeof(System.String)) &&
                                        (piTargetProperty.PropertyType.IsGenericType) &&
                                        (piTargetProperty.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) &&
                                        ((new NullableConverter(piTargetProperty.PropertyType)).UnderlyingType == typeof(System.DateTime)))
                                    {
                                        // The below pattern dd-MMM-YY is for an Oracle date target. You may need to change this depending
                                        // on the database being used.
                                        DateTime dt = DateTime.ParseExact(drData[column.ToString()].ToString(), "dd-MMM-YY", CultureInfo.CurrentCulture);
                                        piTargetProperty.SetValue(targetClass, dt, null);
                                    }
                                    else // Set the value which matches the property type.
                                        piTargetProperty.SetValue(targetClass, drData[column.ToString()], null);
                                }
                                break; // Column name and data associated, no need to look at the rest of the columns.
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(string.Format("Load Failure of the Attribute ({0}) for {1}. Exception:{2}",
                            ((XmlElementAttribute)aTargetAttribute).ElementName, targetType.Name, ex.Message));
                    }
                }
            }
            return targetClass;
        }
    }

}