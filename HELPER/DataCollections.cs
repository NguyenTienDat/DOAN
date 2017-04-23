using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class DataCollections : CollectionBase
{
    String _DataTable = "";
    String _ORDERBY = "";
    String _Filter = "";
    public DataCollections(String m_TableName)
    {
        this._DataTable = m_TableName;
    }
    public string FILTER
    {
        get
        {
            return _Filter;
        }
        set
        {
            _Filter = value;
        }
    }
    public string ORDERBY
    {
        get
        {
            return _ORDERBY;
        }
        set
        {
            _ORDERBY = value;
        }
    }
    public string DataTable
    {
        get
        {
            return _DataTable;
        }
        set
        {
            _DataTable = value;
        }
    }
    public void Add(DataTypes _DataType, String _DataField, FieldTypes _FieldType, Object _DataValue, String _Expression)
    {
        DataItems fField = new DataItems();
        fField.DataType = _DataType;
        fField.FieldType = _FieldType;
        fField.DataValue = _DataValue;
        fField.DataField = _DataField;
        fField.Expression = _Expression;
        base.List.Add(fField);
    }
    public void Add(String _DataType, String _DataField, FieldTypes _FieldType, Object _DataValue, String _Expression)
    {
        DataItems fField = new DataItems();
        if (_DataType.ToUpper() == "NUMBER")
        {
            fField.DataType = DataTypes.Number;
        }
        else if (_DataType.ToUpper() == "NVARCHAR")
        {
            fField.DataType = DataTypes.NVarchar;
        }
        else if (_DataType.ToUpper() == "DATETIME")
        {
            fField.DataType = DataTypes.DateTime;
        }
        else
        {
            fField.DataType = DataTypes.Undefined;
        }
        fField.FieldType = _FieldType;
        fField.DataValue = _DataValue;
        fField.DataField = _DataField;
        fField.Expression = _Expression;
        base.List.Add(fField);
    }
    public void Remove(DataItems value)
    {
        base.List.Remove(value);
    }
    public bool Contains(DataItems value)
    {
        return base.List.Contains(value);
    }
    public DataItems this[int id]
    {
        get
        {
            return (DataItems)base.List[id];
        }
        set
        {
            base.List[id] = value;
        }
    }
    public DataItems this[String p_DataField]
    {
        get
        {
            foreach (DataItems obj in base.List)
            {
                if (obj.DataField == p_DataField)
                {
                    return obj;
                }
            }
            return null;
             
        }
         
    }
    public new int Count()
    {
        return base.List.Count;
    }
}

