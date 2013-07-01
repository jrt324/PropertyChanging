﻿using System;
using System.ComponentModel;
using PropertyChanging;

public class ClassWithBeforeImplementation : INotifyPropertyChanging
{

    public string Property1 { get; set; }
    [DependsOn("Property1")]
    public string Property2 { get; set; }

    public event PropertyChangingEventHandler PropertyChanging;

    public void OnPropertyChanging(string propertyName, object before)
    {
        ValidateIsString(before);

        var handler = PropertyChanging;
        if (handler != null)
        {
            handler(this, new PropertyChangingEventArgs(propertyName));
        }
    }

    void ValidateIsString(object value)
    {
        if (value != null)
        {
            var name = value.GetType().Name;
            if (name != "String")
            {
                throw new Exception(string.Format("Value should be string but is '{0}'.", name));
            }
        }
    }
}