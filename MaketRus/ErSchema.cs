using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace ErEditorProject
{
    public abstract class Observee
    {
        public List<Observer> observers;
        public void Attach(Observer observer)
        {
            if(!observers.Contains(observer))
                observers.Add(observer);
        }

        public void Dettach(Observer observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void Notify()
        {
            foreach (var item in observers)
            {
                item.ObsUpdate();
            }
        }
    }
    public interface Observer
    {
        public void ObsUpdate();
    }

    public class ErSchema
    {
        public string name;
        public List<ErEntitySet> entitySets;
        public List<ErRelationshipSet> relationshipSets;
        public List<ErValueSet> valueSets;

        public ErSchema()
        {
            name = "";
            entitySets = new List<ErEntitySet>();
            relationshipSets = new List<ErRelationshipSet>();
            valueSets = new List<ErValueSet>();
        }

        public ErEntitySet? FindEntitySet(string name)
        {
            return entitySets.Find(x => x.name == name);
        }

        public ErValueSet? FindValueSet(string name)
        {
            return valueSets.Find(x => x.name == name);
        }
    }

    public abstract class ErElement : Observee
    {
        public string name = null!;
        public ErSchema schema;
        public void SetName(string _name)
        {
            name = _name;
            Notify();
        }
    }

    public abstract class ErElementWithAttributes : ErElement
    {
        public List<ErAttribute> attributes;
    }

    public class ErEntitySet : ErElementWithAttributes
    {
        public List<ErRole> roles;
        public ErEntitySet()
        {
            this.name = String.Empty;
            observers = new List<Observer>();
            attributes = new List<ErAttribute>();
            roles = new List<ErRole>();
        }
        
        public ErEntitySet(string name)
        {
            this.name = name;
            observers = new List<Observer>();
            attributes = new List<ErAttribute>();
            roles = new List<ErRole>();
        }

        public override string ToString()
        {
            string desc = String.Format($"Entity Set \"{name}\"");
            if(attributes.Count > 0)
            {
                desc += "\n\tAttributes:";
                foreach(ErAttribute attr in attributes)
                {
                    desc += String.Format($"\n\t\t{attr.ToString()}");
                }
            }
            return desc;
        }

        public void AddRole(ErRole role)
        {
            roles.Add(role);
            Notify();
        }

        public void RemoveRole(ErRole role)
        {
            if (roles.Contains(role))
            {
                roles.Remove(role);
                Notify();
            }
            
        }
    }

    public class ErRelationshipSet : ErElementWithAttributes
    {
        public List<ErRole> roles;

        public ErRelationshipSet()
        {
            this.name = String.Empty;
            observers = new List<Observer>();
            attributes = new List<ErAttribute>();
            roles = new List<ErRole>();
        }

        public ErRelationshipSet(string _name)
        {
            this.name = _name;
            observers = new List<Observer>();
            attributes = new List<ErAttribute>();
            roles = new List<ErRole>();
        }
    }

    public class ErValueSet : ErElement
    {
        public ErValueSet()
        {
            name = String.Empty;
            observers = new List<Observer>();
        }

        public ErValueSet(string _name)
        {
            name = _name;
            observers = new List<Observer>();
        }
    }

    public class ErAttribute : ErElement
    {
        public double? minValue;
        public double? maxValue;
        public string? allowedValues;
        public bool isKey;

        public List<ErValueSet> valueSets;

        public ErAttribute()
        {
            this.name = String.Empty;
            isKey = false;
            observers = new List<Observer>();
            valueSets = new List<ErValueSet>();
        }

        public ErAttribute(string name)
        {
            this.name = name;
            isKey = false;
            observers = new List<Observer>();
            valueSets = new List<ErValueSet>();
        }

        public override string ToString()
        {
            string desc = String.Format($"{name}");
            return desc;
        }
    }

    public class ErRole : ErElement
    {
        public ErEntitySet? entitySet;
        public int? minCardinalityWhenImage;
        public int? maxCardinalityWhenImage;
        public int? minCardinalityWhenPreimage;
        public int? maxCardinalityWhenPreimage;

        public bool isIdDependency;
        public bool isKey;

        public ErRole()
        {
            this.name = String.Empty;
            observers = new List<Observer>();
            isIdDependency = false;
            isKey = false;
            this.entitySet = null;
        }

        public ErRole(string _name, ErEntitySet entitySet)
        {
            this.name = _name;
            observers = new List<Observer>();
            isIdDependency = false;
            isKey = false;
            this.entitySet = entitySet;
        }

        public void AddEntitySet(ErEntitySet _entitySet)
        {
            entitySet = _entitySet;
            Notify();
        }
    }
}
