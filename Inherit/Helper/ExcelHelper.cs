using Inherit.Entities;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GTIC.Sincronizador.Helpers
{
    public static class ExcelHelper
    {
        public static DataTable GetDataTableFromExcel(string filepath, bool hasHeader = true)
        {
            using var pck = new OfficeOpenXml.ExcelPackage();
            using (var stream = File.OpenRead(filepath))
            {
                pck.Load(stream);
            }
            var ws = pck.Workbook.Worksheets.First();
            DataTable tbl = new();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }
            var startRow = hasHeader ? 2 : 1;
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = tbl.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return tbl;
        }

        public static List<T> GetListFromExcel<T>(string filepath, bool hasHeader = true) where T : class
        {
            var dt = GetDataTableFromExcel(filepath, hasHeader);
            var result = ConvertDataTable<T>(dt);
            return result;
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    try
                    {
                        if (pro.Name.ToUpper() == column.ColumnName.ToUpper())
                        {
                            if (pro.PropertyType == typeof(DateTime) || pro.PropertyType == typeof(DateTime?))
                            {
                                if (dr[column.ColumnName] != null && !string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                                {
                                    var fecha = DateTime.TryParseExact(dr[column.ColumnName].ToString(), "dd/MM/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime fechaConvertida);
                                    pro.SetValue(obj, fecha ? fechaConvertida : null, null);
                                }                              
                                else
                                    pro.SetValue(obj, null, null);
                                //pro.SetValue(obj,dr[column.ColumnName] != null && !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? DateTime.ParseExact(dr[column.ColumnName].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture): null, null);
                            }
                            else if (pro.PropertyType == typeof(int) || pro.PropertyType == typeof(int?))
                            {
                                pro.SetValue(obj, dr[column.ColumnName] != null && !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? Int32.Parse(dr[column.ColumnName].ToString()) : null, null);
                            }
                            else if (pro.PropertyType == typeof(bool) || pro.PropertyType == typeof(bool?))
                            {
                                pro.SetValue(obj, bool.Parse(dr[column.ColumnName].ToString()), null);
                            }
                            else if (pro.PropertyType == typeof(double) || pro.PropertyType == typeof(double?))
                            {
                                pro.SetValue(obj, dr[column.ColumnName] != null && !string.IsNullOrEmpty(dr[column.ColumnName].ToString()) ? double.Parse(dr[column.ColumnName].ToString()) : null, null);
                            }
                            else
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        continue;
                    }
                   
                }
            }
            return obj;
        }

        public static void ActualizarEntidad<T>(string excelFilePath, T entidadActualizada) where T : class
        {
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault(); // Suponiendo que hay una sola hoja en el archivo Excel.

                if (worksheet != null)
                {
                    PropertyInfo[] propiedades = typeof(T).GetProperties();

                    var idPropiedad = propiedades.FirstOrDefault(p => p.Name == "ID");
                    if (idPropiedad != null)
                    {
                        int id = (int)idPropiedad.GetValue(entidadActualizada);
                        var idCell = worksheet.Cells["A:A"].FirstOrDefault(c => c.Text.Equals(id.ToString()));

                        int rowToUpdate;
                        if (idCell != null)
                        {
                            // ID encontrado, obtener la fila a actualizar.
                            rowToUpdate = idCell.Start.Row;
                        }
                        else
                        {
                            // ID no encontrado, agregar en la siguiente fila disponible.
                            rowToUpdate = worksheet.Dimension.End.Row + 1;
                        }

                        foreach (var propiedad in propiedades)
                        {
                            if (Attribute.IsDefined(propiedad, typeof(NoCopiarAttribute)))                            
                                continue; // Ignorar propiedades con el atributo NoCopiar
                            
                            int columnIndex = Array.IndexOf(propiedades, propiedad) + 1;

                            object valor = propiedad.GetValue(entidadActualizada);
                            if (valor is bool)
                                worksheet.Cells[rowToUpdate, columnIndex].Value = (bool)valor ? "true" : "false";
                            else if (valor is DateTime)
                                worksheet.Cells[rowToUpdate, columnIndex].Value = ((DateTime)valor).Date.ToString();
                            else
                                worksheet.Cells[rowToUpdate, columnIndex].Value = valor;
                        }

                        package.Save();
                    }
                    else
                    {
                        throw new InvalidOperationException("La entidad no tiene una propiedad 'ID'.");
                    }
                }
            }
        }

        public static void EliminarEntidad<T>(string excelFilePath, int id) where T : class
        {
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault(); // Suponiendo que hay una sola hoja en el archivo Excel.

                if (worksheet != null)
                {
                    PropertyInfo[] propiedades = typeof(T).GetProperties();

                    var idPropiedad = propiedades.FirstOrDefault(p => p.Name == "ID");
                    if (idPropiedad != null)
                    {
                        var idCell = worksheet.Cells["A:A"].FirstOrDefault(c => c.Text.Equals(id.ToString()));

                        if (idCell != null)
                        {
                            // ID encontrado, obtener la fila a eliminar.
                            int rowToDelete = idCell.Start.Row;

                            // Eliminar la fila.
                            worksheet.DeleteRow(rowToDelete);

                            // Guardar los cambios en el archivo.
                            package.Save();
                        }
                        else
                        {
                            throw new InvalidOperationException("El ID especificado no se encontró en el archivo Excel.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("La entidad no tiene una propiedad 'ID'.");
                    }
                }
            }
        }

    }
}
