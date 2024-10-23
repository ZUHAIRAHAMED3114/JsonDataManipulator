using Newtonsoft.Json.Linq;

namespace JsonDataaManipulation
{
    public class JsonQDM
    {
        /*
         JObject.Parse(): Used for parsing a single JSON object (enclosed in {}).
         JArray.Parse(): Used for parsing a JSON array (enclosed in []).
         */
        public void JsonObjectMethod()
        {
            # region Creation of Jobject
            var product = new JObject
            {
                ["id"] = "P12345",
                ["name"] = "Widget 3000",
                ["category"] = "Widgets",
                ["dimensions"] = new JObject
                {
                    ["length"] = null,
                    ["width"] = 5.5,
                    ["height"] = 3.2
                },
                ["price"] = 100,
                ["discount"] = 15,
                ["availability"] = "In stock",
                ["manufacturer"] = new JObject
                {
                    ["name"] = "WidgetCo",
                    ["address"] = "123 Widget Street, Widgetville, USA"
                },
                ["created_at"] = "2023-07-10 10:30:00"
            };

            //2nd Method
            var productDeclarative = new JObject(
               new JProperty("id", "P12345"),
               new JProperty("name", "Widget 3000"),
               new JProperty("category", "Widgets"),
               new JProperty("dimensions", new JObject(
                   new JProperty("length", null),
                   new JProperty("width", 5.5),
                   new JProperty("height", 3.2)
               )),
               new JProperty("price", 100),
               new JProperty("discount", 15),
               new JProperty("availability", "In stock"),
               new JProperty("manufacturer", new JObject(
                   new JProperty("name", "WidgetCo"),
                   new JProperty("address", "123 Widget Street, Widgetville, USA")
               )),
               new JProperty("created_at", "2023-07-10 10:30:00")
           );
            // ParseMethod


            string jsonString = @"
                            {
                              ""product"": {
                                ""id"": ""P12345"",
                                ""name"": ""Widget 3000"",
                                ""category"": ""Widgets"",
                                ""dimensions"": {
                                  ""length"": null,
                                  ""width"": 5.5,
                                  ""height"": 3.2
                                },
                                ""price"": 100,
                                ""discount"": 15,
                                ""availability"": ""In stock"",
                                ""manufacturer"": {
                                  ""name"": ""WidgetCo"",
                                  ""address"": ""123 Widget Street, Widgetville, USA""
                                },
                                ""created_at"": ""2023-07-10 10:30:00""
                              }
                           }";

            var product3 = JObject.Parse(jsonString);

            #endregion
            #region Retrieving Data
            Console.WriteLine(product.ToString());
            string id = product["id"]?.ToString();
            string name = product["name"]?.ToString();
            string category = product["category"]?.ToString();

            // Accessing the nested dimensions object
            var dimensions = product["dimensions"] as JObject;
            double? length = dimensions?["length"]?.ToObject<double?>(); // Using nullable double
            double width = dimensions?["width"]?.ToObject<double>() ?? 0; // Default to 0 if null
            double height = dimensions?["height"]?.ToObject<double>() ?? 0;

            #endregion
        }
        public void JsonArrayOjbectMethod() {
            

            string jsonString = @"
                                    [{
                                      ""product"": {
                                        ""id"": ""P12345"",
                                        ""name"": ""Widget 3000"",
                                        ""category"": ""Widgets"",
                                        ""dimensions"": {
                                          ""length"": null,
                                          ""width"": 5.5,
                                          ""height"": 3.2
                                        },
                                        ""price"": 100,
                                        ""discount"": 15,
                                        ""availability"": ""In stock"",
                                        ""manufacturer"": {
                                          ""name"": ""WidgetCo"",
                                          ""address"": ""123 Widget Street, Widgetville, USA""
                                        },
                                        ""created_at"": ""2023-07-10 10:30:00""
                                      }
                                    },
                                    {
                                      ""product"": {
                                        ""id"": ""P6789 next"",
                                        ""name"": ""Widget 3001 next "",
                                        ""category"": ""Widgets next"",
                                        ""dimensions"": {
                                          ""length"": null,
                                          ""width"": 5.5,
                                          ""height"": 3.2
                                        },
                                        ""price"": 100,
                                        ""discount"": 15,
                                        ""availability"": ""In stock"",
                                        ""manufacturer"": {
                                          ""name"": ""WidgetCo"",
                                          ""address"": ""123 Widget Street, Widgetville, USA""
                                        },
                                        ""created_at"": ""2023-07-10 10:30:00""
                                      }
                                    }
                                ]";

            
            var productArray = JArray.Parse(jsonString);
            var lastProduct = productArray.Last;

            foreach (var product in productArray)
            {
                var productObject = product;
                #region reading IntendedJsonValue
                Console.WriteLine(productObject["product"]["price"]);
               
                var intprice = productObject["product"]["price"].Value<int>();
                Console.WriteLine(intprice);
                #endregion
            }

        }
        public void JsonArrayWithLinqMethod()
        {


            string jsonString = @"
                                    [{
                                      ""product"": {
                                        ""id"": ""P12345"",
                                        ""name"": ""Widget 3000"",
                                        ""category"": ""Widgets"",
                                        ""dimensions"": {
                                          ""length"": null,
                                          ""width"": 5.5,
                                          ""height"": 3.2
                                        },
                                        ""price"": 100,
                                        ""discount"": 15,
                                        ""availability"": ""In stock"",
                                        ""manufacturer"": {
                                          ""name"": ""WidgetCo"",
                                          ""address"": ""123 Widget Street, Widgetville, USA""
                                        },
                                        ""created_at"": ""2023-07-10 10:30:00""
                                      }
                                    },
                                    {
                                      ""product"": {
                                        ""id"": ""P6789 next"",
                                        ""name"": ""Widget 3001 next "",
                                        ""category"": ""Widgets next"",
                                        ""dimensions"": {
                                          ""length"": null,
                                          ""width"": 5.5,
                                          ""height"": 3.2
                                        },
                                        ""price"": 100,
                                        ""discount"": 15,
                                        ""availability"": ""In stock"",
                                        ""manufacturer"": {
                                          ""name"": ""WidgetCo"",
                                          ""address"": ""123 Widget Street, Widgetville, USA""
                                        },
                                        ""created_at"": ""2023-07-10 10:30:00""
                                      }
                                    }
                                ]";


            var productArray = JArray.Parse(jsonString);
            var lastProduct = productArray.Last;

            var x = (from pA in productArray
                     select pA["product"]["name"]);
            x.ToList().ForEach(y => Console.WriteLine(y));

        }
        public void JsonObjectWithSelectToken()
        {
            var product = new JObject
            {
                ["id"] = "P12345",
                ["name"] = "Widget 3000",
                ["category"] = "Widgets",
                ["dimensions"] = new JObject
                {
                    ["length"] = null,
                    ["width"] = 5.5,
                    ["height"] = 3.2
                },
                ["price"] = 100,
                ["discount"] = 15,
                ["availability"] = "In stock",
                ["manufacturer"] = new JObject
                {
                    ["name"] = "WidgetCo",
                    ["address"] = "123 Widget Street, Widgetville, USA"
                },
                ["created_at"] = "2023-07-10 10:30:00"
            };

            JToken productwidth = product.SelectToken(@"$.dimensions.width");
            Console.WriteLine(productwidth);

            string jsonString = @"
                            {
                              ""product"": {
                                ""id"": ""P12345"",
                                ""name"": ""Widget 3000"",
                                ""category"": ""Widgets"",
                                ""dimensions"": {
                                  ""length"": null,
                                  ""width"": 5.5,
                                  ""height"": 3.2
                                },
                                ""price"": 100,
                                ""discount"": 15,
                                ""availability"": ""In stock"",
                                ""manufacturer"": {
                                  ""name"": ""WidgetCo"",
                                  ""address"": ""123 Widget Street, Widgetville, USA""
                                },
                                ""created_at"": ""2023-07-10 10:30:00""
                              }
                           }";

            var product2 = JObject.Parse(jsonString);
            JToken product2width = product2.SelectToken(@"$.product.dimensions.width");
            Console.WriteLine(product2width);

        }


        public void AddingNewFeild(string token,string value) {

            string jsonString = @"
                            {
                              ""product"": {
                                ""id"": ""P12345"",
                                ""name"": ""Widget 3000"",
                                ""category"": ""Widgets"",
                                ""dimensions"": {
                                  ""length"": null,
                                  ""width"": 5.5,
                                  ""height"": 3.2
                                },
                                ""price"": 100,
                                ""discount"": 15,
                                ""availability"": ""In stock"",
                                ""manufacturer"": {
                                  ""name"": ""WidgetCo"",
                                  ""address"": ""123 Widget Street, Widgetville, USA""
                                },
                                ""created_at"": ""2023-07-10 10:30:00""
                              }
                           }";

            var product2 = JObject.Parse(jsonString);
            JToken product2width = product2.SelectToken($"$.{token}");
            if (product2width == null) 
            {
                
                var lastParmeter = token.Split('.').Last();
                product2[lastParmeter] = value;
                
                // Here if More than Two or More Depths are then Then Need to Do DFS Logic To Append...
                
            }

            Console.WriteLine(product2.ToString());
        }
    
    }
}
