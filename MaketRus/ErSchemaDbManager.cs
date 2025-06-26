using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Xml.Linq;

namespace ErEditorProject
{
    public class ErSchemaDbData
    {
        public ErSchema schema;
        public string filePath;
        private Dictionary<int, ErElement> inMemoryIdMap;
        // здесь же можно будет контролировать изменения (журнал)

        public ErSchemaDbData(ErSchema _schema, string _filePath)
        {
            schema = _schema;
            filePath = _filePath;
            inMemoryIdMap = new Dictionary<int, ErElement>();
        }

        public ErSchema MapToErSchema()
        {
            ErSchemaDbContext dbcontext = new ErSchemaDbContext(filePath);
            if (dbcontext.Database.CanConnect())
            {
                schema.entitySets = MapDbSetToErSet(dbcontext.entitySets.ToList(), schema.entitySets, MapToEntitySet, dbcontext);
                schema.relationshipSets = MapDbSetToErSet(dbcontext.relationshipSets.ToList(), schema.relationshipSets, MapToRelationshipSet, dbcontext);
                schema.valueSets = MapDbSetToErSet(dbcontext.valueSets.ToList(), schema.valueSets, MapToValueSet, dbcontext);
            }
            else
            {
                Console.WriteLine("Cannot connect to the database");
            }
            dbcontext.Dispose();
            return schema;
        }

        public bool MapToDatabase()
        {
            ErSchemaDbContext dbcontext = new ErSchemaDbContext(filePath);
            if (dbcontext.Database.CanConnect())
            {
                MapErSetToDbSet(schema.entitySets, MapFromEntitySet, dbcontext);
                MapErSetToDbSet(schema.relationshipSets, MapFromRelationshipSet, dbcontext);
                MapErSetToDbSet(schema.valueSets, MapFromValueSet, dbcontext);
                dbcontext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Cannot connect to the database");
            }
            dbcontext.Dispose();
            return true;
        }


        // преобразования всех элементов
        private List<T2> MapDbSetToErSet<T1, T2>(List<T1> dbSet, List<T2> erSet, Func<ErSchemaDbContext, T1, T2> Map, ErSchemaDbContext context)
        {
            dbSet.ForEach(dbEl =>
            {
                erSet.Add(Map(context, dbEl));
            });
            return erSet;
        }

        private void MapErSetToDbSet<T1, T2>(List<T1> erSet, Func<ErSchemaDbContext, T1, T2> Map, ErSchemaDbContext context)
        {
            erSet.ForEach(erEl =>
            {
                Map(context, erEl);
            });
        }

        private ErEntitySet MapToEntitySet(ErSchemaDbContext context, DbEntitySet dbEs)
        {
            ErEntitySet entitySet;
            if (inMemoryIdMap.ContainsKey(dbEs.id))
            {
                entitySet = (ErEntitySet)inMemoryIdMap[dbEs.id];
            }
            else
            {
                entitySet = new ErEntitySet(dbEs.name);
                entitySet.attributes = MapDbSetToErSet(context.attributes.Where(x => x.parentId == dbEs.id).ToList(), entitySet.attributes, MapToAttribute, context);
                Console.WriteLine(entitySet.attributes.Count);
                inMemoryIdMap[dbEs.id] = entitySet;
            }
            return entitySet;
        }

        private DbEntitySet MapFromEntitySet(ErSchemaDbContext dbcontext, ErEntitySet es)
        {
            DbEntitySet db = new DbEntitySet();
            db.name = es.name;
            if (inMemoryIdMap.ContainsValue(es))
            {
                db.id = inMemoryIdMap.Where(x => x.Value == es).ToList()[0].Key;
                dbcontext.Update(db);
            }
            else
            {
                dbcontext.Add(db);
                dbcontext.SaveChanges();
                inMemoryIdMap.Add(db.id, es);
            }
            foreach (var item in es.attributes)
            {
                var dbattr = MapFromAttribute(dbcontext, item);
                //dbattr.parent = db;
                db.attributes.Add(dbattr);
                dbcontext.SaveChanges();
                inMemoryIdMap[dbattr.id] = item;
            }
            return db;
        }

        private DbAttribute MapFromAttribute(ErSchemaDbContext dbcontext, ErAttribute attr)
        {
            DbAttribute db = new DbAttribute();
            db.name = attr.name;
            db.minValue = attr.minValue;
            db.maxValue = attr.maxValue;
            db.allowedValues = attr.allowedValues;

            if (inMemoryIdMap.ContainsValue(attr))
            {
                db.id = inMemoryIdMap.Where(x => x.Value == attr).ToList()[0].Key;
                dbcontext.Update(db);
            }
            else
            {
                dbcontext.Add(db);
                //dbcontext.SaveChanges();
                //inMemoryIdMap.Add(db.id, attr);
            }
            return db;
        }

        private ErRelationshipSet MapToRelationshipSet(ErSchemaDbContext context, DbRelationshipSet dbRs)
        {
            ErRelationshipSet relationshipSet;
            if (inMemoryIdMap.ContainsKey(dbRs.id))
            {
                relationshipSet = (ErRelationshipSet)inMemoryIdMap[dbRs.id];
            }
            else
            {
                relationshipSet = new ErRelationshipSet(dbRs.name);

                Console.WriteLine(dbRs.attributes.Count);
                relationshipSet.attributes = MapDbSetToErSet(context.attributes.Where(x => x.parentId == dbRs.id).ToList(), relationshipSet.attributes, MapToAttribute, context);
                
                relationshipSet.roles = MapDbSetToErSet(context.roles.Where(x => x.relationshipSetId == dbRs.id).ToList(), relationshipSet.roles, MapToRole, context);
                inMemoryIdMap[dbRs.id] = relationshipSet;
            }
            return relationshipSet;
        }

        private DbRelationshipSet MapFromRelationshipSet(ErSchemaDbContext dbcontext, ErRelationshipSet es)
        {
            DbRelationshipSet db = new DbRelationshipSet();
            db.name = es.name;
            if (inMemoryIdMap.ContainsValue(es))
            {
                db.id = inMemoryIdMap.Where(x => x.Value == es).ToList()[0].Key;
                dbcontext.Update(db);
            }
            else
            {
                dbcontext.Add(db);
                dbcontext.SaveChanges();
                inMemoryIdMap.Add(db.id, es);
            }
            foreach (var item in es.attributes)
            {
                var dbattr = MapFromAttribute(dbcontext, item);
                db.attributes.Add(dbattr);
                dbcontext.SaveChanges();
                inMemoryIdMap[dbattr.id] = item;
            }
            foreach (var item in es.roles)
            {
                var dbattr = MapFromRole(dbcontext, item);
                db.roles.Add(dbattr);
                dbcontext.SaveChanges();
                inMemoryIdMap[dbattr.id] = item;
            }

            return db;
        }

        private DbRole MapFromRole(ErSchemaDbContext dbcontext, ErRole role)
        {
            DbRole db = new DbRole();
            db.name = role.name;
            if(role.entitySet != null)
            {
                int key = (inMemoryIdMap.Where(y => y.Value == role.entitySet).ToList()[0].Key);
                var dbes = dbcontext.entitySets.Where(x => x.id == key).ToList()[0];
                db.entitySet = dbes;
                //db.entitySetId = dbes.id;
            }
            db.isKey = role.isKey;
            if (inMemoryIdMap.ContainsValue(role))
            {
                db.id = inMemoryIdMap.Where(x => x.Value == role).ToList()[0].Key;
                dbcontext.Update(db);
            }
            else
            {
                dbcontext.Add(db);
            }
            return db;
        }

        private ErValueSet MapToValueSet(ErSchemaDbContext context, DbValueSet dbVs)
        {
            ErValueSet valueSet;
            if (inMemoryIdMap.ContainsKey(dbVs.id))
            {
                valueSet = (ErValueSet)inMemoryIdMap[dbVs.id];
            }
            else
            {
                valueSet = new ErValueSet(dbVs.name);
                inMemoryIdMap[dbVs.id] = valueSet;
            }
            return valueSet;
        }

        private DbValueSet MapFromValueSet(ErSchemaDbContext dbcontext, ErValueSet es)
        {
            DbValueSet db = new DbValueSet();
            db.name = es.name;
            if (inMemoryIdMap.ContainsValue(es))
            {
                db.id = inMemoryIdMap.Where(x => x.Value == es).ToList()[0].Key;
                dbcontext.Update(db);
            }
            else
            {
                dbcontext.Add(db);
                dbcontext.SaveChanges();
                inMemoryIdMap.Add(db.id, es);
            }
            return db;
        }

        private ErAttribute MapToAttribute(ErSchemaDbContext context, DbAttribute dbAttr)
        {
            ErAttribute attribute;
            if (inMemoryIdMap.ContainsKey(dbAttr.id))
            {
                attribute = (ErAttribute)inMemoryIdMap[dbAttr.id];
            }
            else
            {
                attribute = new ErAttribute(dbAttr.name);
                attribute.minValue = dbAttr.minValue;
                attribute.maxValue = dbAttr.maxValue;
                attribute.allowedValues = dbAttr.allowedValues;
                attribute.isKey = dbAttr.isKey;
                foreach (DbValueSet dbVs in dbAttr.valueSets)
                {
                    ErValueSet vs = MapToValueSet(context, dbVs);
                    attribute.valueSets.Add(vs);
                }
                inMemoryIdMap[dbAttr.id] = attribute;
            }
            return attribute;
        }

        private ErRole MapToRole(ErSchemaDbContext context, DbRole dbRole)
        {
            ErRole role;
            if (inMemoryIdMap.ContainsKey(dbRole.id))
            {
                role = (ErRole)inMemoryIdMap[dbRole.id];
            }
            else
            {
                role = new ErRole(dbRole.name, MapToEntitySet(context, dbRole.entitySet));
                role.maxCardinalityWhenImage = dbRole.maxCardinalityOfImage;
                role.minCardinalityWhenImage = dbRole.minCardinalityOfImage;
                role.maxCardinalityWhenPreimage = dbRole.maxCardinalityOfPreimage;
                role.minCardinalityWhenPreimage = dbRole.minCardinalityOfPreimage;
                role.isKey = dbRole.isKey;
                role.isIdDependency = dbRole.IdDependency;
                inMemoryIdMap[dbRole.id] = role;
            }
            return role;
        }

    }
    public class ErSchemaDbManager
    {
        private static ErSchemaDbManager? erSchemaDbManager = null;
        private List<ErSchemaDbData> openSchemas;
        private ErSchemaDbManager() {
            openSchemas = new List<ErSchemaDbData>();
        }

        public static ErSchemaDbManager Manager()
        {
            if (erSchemaDbManager == null)
            {
                erSchemaDbManager = new ErSchemaDbManager();
            }
            return erSchemaDbManager;
        }

        public ErSchema NewErSchema(string erSchemaFilePath, string erSchemaFileName)
        {
            openSchemas.Clear();
            string path = Path.Combine(erSchemaFilePath, erSchemaFileName +".db");
            ErSchema schema = new ErSchema();
            schema.name = erSchemaFileName;

            ErSchemaDbContext dbcontext = new ErSchemaDbContext(path);
            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();
            dbcontext.Dispose();

            ErSchemaDbData dbdata = new ErSchemaDbData(schema, path);
            openSchemas.Add(dbdata);
            return schema;
        }

        public ErSchema OpenErSchema(string erSchemaFullFileName)
        {
            openSchemas.Clear();
            string path = erSchemaFullFileName;
            ErSchema schema = new ErSchema();
            schema.name = Path.GetFileNameWithoutExtension(erSchemaFullFileName);

            ErSchemaDbContext dbcontext = new ErSchemaDbContext(path);
            if (!dbcontext.Database.CanConnect())
            {
                dbcontext.Dispose();
                throw new Exception("Cannot open scheme file");
            }
            dbcontext.Dispose();

            ErSchemaDbData dbdata = new ErSchemaDbData(schema, path);
            openSchemas.Add(dbdata);
            schema = dbdata.MapToErSchema();
            foreach (var item in schema.entitySets)
            {
                item.schema = schema;
                foreach (var item1 in item.attributes)
                {
                    item1.schema = schema;
                }
                foreach (var item1 in schema.relationshipSets)
                {
                    foreach (var item2 in item1.roles)
                    {
                        if (item2.entitySet == item)
                        {
                            item.roles.Add(item2);
                        }
                    }
                }
            }
            foreach (var item in schema.relationshipSets)
            {
                item.schema = schema;
                foreach (var item1 in item.attributes)
                {
                    item1.schema = schema;
                }
                foreach (var item1 in item.roles)
                {
                    item1.schema = schema;
                }
            }
            foreach (var item in schema.valueSets)
            {
                item.schema = schema;
            }
            return schema;
        }

        public bool SaveSchema(ErSchema schema)
        {
            ErSchemaDbData? data = openSchemas.Find(x => x.schema == schema);
            if(data == null)
            {
                return false;
            }
            ErSchemaDbContext dbcontext = new ErSchemaDbContext(data.filePath);
            if (!dbcontext.Database.CanConnect())
            {
                dbcontext.Dispose();
                throw new Exception("Cannot open scheme file");
            }
            dbcontext.Dispose();

            data.MapToDatabase();

            return true;
        }
    }
 }
