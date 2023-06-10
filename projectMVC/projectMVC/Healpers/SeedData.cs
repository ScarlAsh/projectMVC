using Microsoft.EntityFrameworkCore;
using projectMVC.Data;
//using projectMVC.Enums;
using projectMVC.Models;
using projectMVC.UnitOfWork;
using projectMVC.Models;
using System.Collections.Generic;
using System;
using projectMVC.Enums;

namespace projectMVC.Healpers
{
    public class SeedData
    {
        //private readonly ApplicationDbContext _applicationDbContext;
        //public SeedData(ApplicationDbContext applicationDbContext)
        //{
        //    _applicationDbContext = applicationDbContext;
        //}
        public static  void Seed()
        {
            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();

            bool categoryExists = context.Categories.Any();
            if(!categoryExists)
            {
                context.Categories.AddRange(new List<Category>(){
                    new Category{ Name = "Mobile"}, //1
                    new Category{ Name = "Tablet"}, //2
                    new Category{ Name = "Labtop"}, //3
                    new Category{ Name = "Camera"}, //4
                    new Category{ Name = "HeadPhone"} //5
                });
				context.SaveChanges();

			}
			bool BrandExists = context.Brands.Any();
            if (!BrandExists)
            {
                context.Brands.AddRange(new List<Brand>()
                {
                    new Brand {Name = "Samsong" }, //1
                    new Brand {Name = "Nokia"}, //2
                    new Brand {Name = "Dell"}, //3
                    new Brand {Name = "Lenovo"}, //4
                    new Brand {Name = "Apple"}, //5
                    new Brand {Name = "Hp"}, //6
                    new Brand {Name = "JBL"},//7
                    new Brand {Name = "Sony"},//8
                    new Brand {Name = "Bose"}, //9
                    new Brand {Name = "KVIDIO"},//10
                    new Brand {Name = "Logitech" },//11
                    new Brand {Name ="Huawei"}//12

                });
            context.SaveChanges();

            }

            bool productExists = context.Products.Any();
            if(!productExists) 
            {
                context.Products.AddRange(new List<Product>()
                {
                    //new Product{
                    //            Name = "Samsung Galaxy Tab S6 Lite",
                    //            Price = 12102,
                    //            Color = (int)ProductColors.Black,
                    //            Description = "A tablet that takes all of life’s little knocks - Plus buy from Amazon and get a Rugged Flip Cover included\r\nReliable design and huge 8200mAh battery with fast charging for worry free roaming\r\nStays sharp with 2 years of OS upgrades, stays safe with 3 years of timely security updates\r\nSee every detail with a 2K display\r\nshortdesc: All prices include VAT.\r\nBuy with installments and pay EGP 145.13 for 60 months with select banks",
                    //            RealseDate = new DateTime(2020,7,1),
                    //            UnitsInStock = 10,
                    //            OutOfStock = 0,
                    //            BrandId = 1,
                    //            CategoryId = 2,
                    //            ProductInfos = new List<ProductInfo>()
                    //            {
                    //                new ProductInfo { Info ="Screen : 10.4" },
                    //                new ProductInfo { Info ="RAM : 4 GB" },
                    //                new ProductInfo { Info ="Height : 7L" },
                    //                new ProductInfo { Info ="Width : 154 W " },
                    //                new ProductInfo { Info ="SnapDragon 5800" },
                    //                new ProductInfo { Info ="Operating system : android" },

                    //            },
                    //            Images = new List<Image>()
                    //            {
                    //                new Image { ImageUrl = "SamsungGalaxyTabS6Lite"+1+".jpg"},
                    //                new Image { ImageUrl = "SamsungGalaxyTabS6Lite"+2+".jpg"},
                    //                new Image { ImageUrl = "SamsungGalaxyTabS6Lite"+3+".jpg"},
                    //                new Image { ImageUrl = "SamsungGalaxyTabS6Lite"+4+".jpg"}

                    //            }
                    //},


                    new Product{
                                Name = "Dell Vostro 3510 laptop",
                                Price = 15329,
                                Color = (int)ProductColors.Black,
                                Description = "Dell Vostro 3510 laptop \r\n11th Intel core i3-1115G4\r\n12 GB RAM, 256 GB SSD\r\n15.6\" HD (1366X768) Anti-glare - Black \r\nGood Quality \r\nPerfect Material \r\nEasy to use \r\nUnique and fashionable design. ",
                                RealseDate = new DateTime(2022,01,28),
                                UnitsInStock = 6,
                                OutOfStock = 0,
                                BrandId = 3,
                                CategoryId = 3,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Screen : 15.6" },
                                    new ProductInfo { Info ="RAM : 12 GB" },


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="DellVostro3510laptop"+1+".jpg"},
                                    new Image { ImageUrl ="DellVostro3510laptop"+2+".jpg"},
                                    new Image { ImageUrl ="DellVostro3510laptop"+3+".jpg"},
                                    new Image { ImageUrl ="DellVostro3510laptop"+4+".jpg"},
                                    new Image { ImageUrl ="DellVostro3510laptop"+5+".jpg"},
                                    new Image { ImageUrl ="DellVostro3510laptop"+6+".jpg"}
                                },
                                Sale=2

                    },

                    new Product{
                                Name = "Lenovo Ideapad 5 15IAL7",
                                Price = 25999,
                                Color = (int)ProductColors.Grey,
                                Description = "Processor: Intel Core i7-1255U, 10Cores \r\nMemory: 16GB Soldered DDR4-3200 \r\n15.6\" Storage: 512GB SSD M.2 2242 PCIe 4.0x4 NVMe  \r\nGraphics: Integrated Intel Iris Xe Graphics  \r\nFingerprint: Touch Style, Integrated in Power Button  \r\nDisplay: 15.6-inch FHD (1920x1080)  \r\nOS & Color: Windows 11 Home– Storm Grey . ",
                                RealseDate = new DateTime(2022,09,13),
                                UnitsInStock = 3,
                                OutOfStock = 0,
                                BrandId = 4,
                                CategoryId = 3,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Screen : 15.6" },
                                    new ProductInfo { Info ="RAM : 16 GB" },

                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="LenovoIdeapad515IAL7"+1+".jpg"},
                                    new Image { ImageUrl ="LenovoIdeapad515IAL7"+2+".jpg"},
                                    new Image { ImageUrl ="LenovoIdeapad515IAL7"+3+".jpg"},
                                    new Image { ImageUrl ="LenovoIdeapad515IAL7"+4+".jpg"},
                                    new Image { ImageUrl ="LenovoIdeapad515IAL7"+5+".jpg"},
                                },
                                Sale=5
                    },


                    new Product{
                                Name = "Dell Inspiron 5410 2-in-1 Convertible x360 ",
                                Price = 24700,
                                Color = (int)ProductColors.Silver,
                                Description = "Dell Inspiron 5410 2-in-1 Convertible x360 laptop - 11th Intel Core i5-1135G7, 8GB RAM, 256GB SSD, Intel Iris Xe Graphics, 14\" FHD Touch, FingerPrint, Backlit keyboard, Windows 10 - Silver  \r\nBest Quality  \r\nGood material for customer   \r\nEasy to use . ",
                                RealseDate = new DateTime(2021,04,13),
                                Sale=5,
                                UnitsInStock = 11,
                                OutOfStock = 0,
                                BrandId = 3,
                                CategoryId = 3,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Screen : 14" },
                                    new ProductInfo { Info ="RAM : 8 GB" },

                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="DellInspiron54102-in-1Convertiblex360"+1+".jpg"},
                                    new Image { ImageUrl ="DellInspiron54102-in-1Convertiblex360"+2+".jpg"},
                                    new Image { ImageUrl ="DellInspiron54102-in-1Convertiblex360"+3+".jpg"},
                                    new Image { ImageUrl ="DellInspiron54102-in-1Convertiblex360"+4+".jpg"},
                                    new Image { ImageUrl ="DellInspiron54102-in-1Convertiblex360"+5+".jpg"},
                                }
                    },

                    new Product{
                                Name = "Apple MacBook Pro Late 2020",
                                Price = 37999,
                                Color = (int)ProductColors.Grey,
                                Description = "English Backlit Keyboard \r\nModel Number: MYD82  \r\nHard Disk Interface: solid_state_drive \r\nHardware Platform: MAC OS \r\nProcessor Speed (GHz): 3.2 GHz . ",
                                RealseDate = new DateTime(2020,11,10),
                                Sale=2,
                                UnitsInStock = 8,
                                OutOfStock = 0,
                                BrandId = 5,
                                CategoryId = 3,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Screen : 13" },
                                    new ProductInfo { Info ="RAM : 8 GB" },

                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="AppleMacBookProLate2020"+1+".jpg"},
                                    new Image { ImageUrl ="AppleMacBookProLate2020"+2+".jpg"},
                                    new Image { ImageUrl ="AppleMacBookProLate2020"+3+".jpg"}
                                }
                    },

                    new Product{
                                Name = "HP Probook 450 G8",
                                Price = 25125,
                                Color = (int)ProductColors.Silver,
                                Description = "HP Probook 450 G8 Laptop - 11th Intel Core i5-1135G7, 8GB RAM, 512GB PCIe NVMe SSD, 15.6\" FHD (1920 x 1080) IPS anti-glare 250 nits, Intel Iris X Graphics, Fingerprint, \r\nWindows 11 - silver . ",
                                RealseDate = new DateTime(2013,05,10),
                                UnitsInStock = 15,
                                OutOfStock = 0,
                                BrandId = 6,
                                CategoryId = 3,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Screen : 15.6" },
                                    new ProductInfo { Info ="RAM : 8 GB" },

                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl = "HPProbook450G8"+1+".jpg"},
                                    new Image { ImageUrl = "HPProbook450G8"+2+".jpg"},
                                    new Image { ImageUrl = "HPProbook450G8"+3+".jpg"},
                                    new Image { ImageUrl = "HPProbook450G8"+4+".jpg"}
                                }
                    },

                    new Product{
                                Name = "JBL T510BTROSEU",
                                Price = 499,
                                Color = (int)ProductColors.Rose,
                                Description = "JBL T500PIK Wired On-Ear Headphones with Mic Pink",
                                RealseDate = new DateTime(2020,7,1),
                                UnitsInStock = 10,
                                OutOfStock = 0,
                                BrandId = 7,
                                CategoryId = 5,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="form factor :on Ear" },
                                    new ProductInfo { Info ="Connectivity Technology:wirless" },
                                    new ProductInfo { Info ="Age Range : adult" }
                                    

                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl = "JBL T510BTROSEU"+1+".jpg"},
                                    new Image { ImageUrl = "JBL T510BTROSEU"+2+".jpg"},
                                    new Image { ImageUrl = "JBL T510BTROSEU"+3+".jpg"},
                                    new Image { ImageUrl = "JBL T510BTROSEU"+4+".jpg"}

                                }
                    },

                    new Product{
                                Name = "Sony MDRZX110APBLACK Wired Headphones - Black",
                                Price = 1750,
                                Color = (int)ProductColors.Black,
                                Description = "Sony MDR-ZX110AP Extra Bass Wired Headphones with Mic,\r\n Smartphone Headset for iPhone & Android with in-Line Remote & Microphone\r\n, Neodymium Magnets & 30mm Drivers, Black (Renewed)",
                                RealseDate = new DateTime(2020,7,1),
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 8,
                                CategoryId = 5,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="form factor :on Ear" },
                                    new ProductInfo { Info ="Connectivity Technology:wired" },
                                    new ProductInfo { Info ="Age Range : adult" }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl = "H390-USB-COMPUTER-HEADSET"+1+".jpg"},
                                    new Image { ImageUrl = "H390-USB-COMPUTER-HEADSET"+2+".jpg"},
                                    new Image { ImageUrl = "H390-USB-COMPUTER-HEADSET"+3+".jpg"},
                                    new Image { ImageUrl = "H390-USB-COMPUTER-HEADSET"+4+".jpg"}

                                }
                    },

                    //new Product{
                    //            Name = "KVIDIO Wireless Bluetooth Headset Headphone With Microphone P47",
                    //            Price = 2000,
                    //            Color = (int)ProductColors.Red,
                    //            Description = "KVIDIO [Updated] Bluetooth Headphones Over Ear, 65 Hours Playtime Wireless Headphones with Microphone,\r\nFoldable Lightweight Headset with Deep Bass,\r\nHiFi Stereo Sound for Travel Work Laptop PC Cellphone",
                    //            RealseDate = new DateTime(2021,8,10),
                    //            UnitsInStock = 5,
                    //            OutOfStock = 0,
                    //            BrandId = 10,
                    //            CategoryId = 5,
                    //            ProductInfos = new List<ProductInfo>()
                    //            {
                    //                new ProductInfo { Info ="form factor :Over Ear" },
                    //                new ProductInfo { Info ="Connectivity Technology:Wireless, Wired, Bluetooth 5.2" },
                    //                new ProductInfo { Info ="Age Range : adult" }


                    //            },
                    //            Images = new List<Image>()
                    //            {
                    //                new Image { ImageUrl = "KVIDIO-Wireless-Bluetooth"+1+".jpg"},
                    //                new Image { ImageUrl = "KVIDIO-Wireless-Bluetooth"+2+".jpg"},
                    //                new Image { ImageUrl = "KVIDIO-Wireless-Bluetooth"+3+".jpg"},
                    //                new Image { ImageUrl = "KVIDIO-Wireless-Bluetooth"+4+".jpg"}

                    //            }
                    //},

                    new Product{
                                Name = "Headphones 700",
                                Price = 2500,
                                Color = (int)ProductColors.Black,
                                Description = "Bose Noise Cancelling Headphones 700,Bluetooth, \r\nOver-Ear Wireless with Built-In Microphone \r\nfor Clear Calls & Alexa Voice Control,Black",
                                RealseDate = new DateTime(2020,11,15),
                                Sale=2,
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 10,
                                CategoryId = 5,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="form factor :Over Ear" },
                                    new ProductInfo { Info ="Connectivity Technology:Bluetooth" },
                                    new ProductInfo { Info ="Age Range : adult" }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="Headphones700"+1+".jpg"},
                                    new Image { ImageUrl ="Headphones700"+2+".jpg"},
                                    new Image { ImageUrl ="Headphones700"+3+".jpg"},
                                    new Image { ImageUrl ="Headphones700"+4+".jpg"}

                                }
                    },

                    new Product{
                                Name = "H390 USB COMPUTER HEADSET",
                                Price = 2500,
                                Color = (int)ProductColors.Blue,
                                Description = "Logitech H390 Wired Headset for PC/Laptop,\r\n Stereo Headphones with Noise Cancelling Microphone,\r\n USB, In-Line Controls, Works with Chromebook - Black",
                                RealseDate = new DateTime(2020,11,15),
                                Sale=3,
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 11,
                                CategoryId = 5,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="form factor :On Ear" },
                                    new ProductInfo { Info ="Connectivity Technology:Wired" },
                                    new ProductInfo { Info ="Age Range : adult" }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="H390-USB-COMPUTER-HEADSET"+1+".jpg"},
                                    new Image { ImageUrl ="H390-USB-COMPUTER-HEADSET"+2+".jpg"},
                                    new Image { ImageUrl ="H390-USB-COMPUTER-HEADSET"+3+".jpg"},
                                    new Image { ImageUrl ="H390-USB-COMPUTER-HEADSET"+4+".jpg"}

                                }
                    },

                     new Product{
                                Name = "Samsung Galaxy Tab S6 Lite 64GB 10.4 WiFi Oxford Grey",
                                Price = 12102,
                                Color = (int)ProductColors.Black,
                                Description = "",
                                RealseDate = new DateTime(2022,5,23),
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 1,
                                CategoryId = 2,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="OS : Android 12" },
                                    new ProductInfo { Info ="GPU : Adreno 618" },
                                    new ProductInfo { Info ="CPU : Octa-core " }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="SamsungGalaxyTabS6Lite64GB10.4WiFiOxfordGrey"+1+".jpg"},
                                    new Image { ImageUrl ="SamsungGalaxyTabS6Lite64GB10.4WiFiOxfordGrey"+2+".jpg"},
                                    new Image { ImageUrl ="SamsungGalaxyTabS6Lite64GB10.4WiFiOxfordGrey"+3+".jpg"},
                                    new Image { ImageUrl ="SamsungGalaxyTabS6Lite64GB10.4WiFiOxfordGrey"+4+".jpg"}

                                }
                     },

                     new Product{
                                Name = "SAMSUNG Galaxy Tab A 32GB 4G",
                                Price = 8499,
                                Color = (int)ProductColors.Silver,
                                Description = "",
                                RealseDate = new DateTime(2021,8,23),
                                Sale=5,
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 1,
                                CategoryId = 2,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Operating System: Android" },
                                    new ProductInfo { Info ="storage : 32 GB " },
                                    new ProductInfo { Info ="Screen size: 10.1 Inches" }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="SAMSUNGGalaxyTabA32GB4G"+4+".jpeg"},
                                    new Image { ImageUrl ="SAMSUNGGalaxyTabA32GB4G"+1+".jpeg"},
                                    new Image { ImageUrl ="SAMSUNGGalaxyTabA32GB4G"+3+".jpeg"},
                                    new Image { ImageUrl ="SAMSUNGGalaxyTabA32GB4G"+2+".jpeg"}

                                }
                     },

                     new Product{
                                Name = "Nokia T20 Android Tablet",
                                Price = 5699,
                                Color = (int)ProductColors.Blue,
                                Description = "A tablet that takes all of life’s little knocks - Plus buy from Amazon and get a Rugged Flip Cover included\r\nReliable design and huge 8200mAh battery with fast charging for worry free roaming\r\nStays sharp with 2 years of OS upgrades, stays safe with 3 years of timely security updates\r\nSee every detail with a 2K display",
                                RealseDate = new DateTime(2020,3,1),
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 2,
                                CategoryId = 2,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Operating System : Android" },
                                    new ProductInfo { Info ="Item weight : 189.3 Grams  " },
                                    new ProductInfo { Info ="Memory storage capacity : 64 GB" }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="NokiaT20AndroidTablet"+1+".jpg"},
                                    new Image { ImageUrl ="NokiaT20AndroidTablet"+2+".jpg"},
                                    new Image { ImageUrl ="NokiaT20AndroidTablet"+3+".jpg"},
                                    new Image { ImageUrl ="NokiaT20AndroidTablet"+4+".jpg"}

                                }
                     },

                      new Product{
                                Name = "Samsung Galaxy Tab A7 Lite",
                                Price = 10599,
                                Color = (int)ProductColors.Silver,
                                Description = "Installed RAM memory size 3 GB\r\nSpecial features Fast_charging\r\nGlass front, aluminum back\r\naluminum frame, plastic ends\r\n5100 mAh, non-removable",
                                RealseDate = new DateTime(2019,1,10),
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 1,
                                CategoryId = 2,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Memory storage capacity : 32 GB" },
                                    new ProductInfo { Info ="Operating System : Android 11 " },
                                    new ProductInfo { Info ="Screen size : 8.7 Inches" }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="SamsungGalaxyTabA7Lite"+1+".jpeg"},
                                    new Image { ImageUrl ="SamsungGalaxyTabA7Lite"+2+".jpeg"},
                                    new Image { ImageUrl ="SamsungGalaxyTabA7Lite"+3+".jpeg"},
                                    new Image { ImageUrl ="SamsungGalaxyTabA7Lite"+4+".jpeg"}

                                }
                      },

                       new Product{
                                Name = "Huawei MatePad T10s Tablet",
                                Price = 7999,
                                Color = (int)ProductColors.Blue,
                                Description = "Ideal Children Companion: HUAWEI MatePad T 10s allows your kids to explore freely with age-appropriate content via exclusive access to Kids Corner. It also goes further with six-layered protection to preserve their precious sight.\r\nHUAWEI MatePad T 10s combine EMUI 10.1 octa-core chipset and advanced algorithm\r\n10.1 inch 1920x1200 (FHD) display",
                                RealseDate = new DateTime(2022,10,19),
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 12,
                                CategoryId = 2,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Item weight : 450 Grams" },
                                    new ProductInfo { Info ="Installed RAM memory size : 3 GB " },
                                    new ProductInfo { Info ="Hardware interface : USB" }


                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl ="HuaweiMatePadT10sTablet"+1+".jpeg"},
                                    new Image { ImageUrl ="HuaweiMatePadT10sTablet"+2+".jpeg"},
                                    new Image { ImageUrl ="HuaweiMatePadT10sTablet"+3+".jpeg"},
                                    new Image { ImageUrl ="HuaweiMatePadT10sTablet"+4+".jpeg"}

                                },
                                Sale=3
                       },

					   new Product{
								Name = "Canon EOS 250D",
								Price = 19999,
								Color = (int)ProductColors.Black,
								Description = "Optical Viewfinder - See Things As They Really Are – Clear And Simple\r\n Dual pixel CMOS af and vari-angle screen",
								RealseDate = new DateTime(2020,11,18),
                                Sale=5,
                                UnitsInStock = 5,
								OutOfStock = 0,
								BrandId = 12,
								CategoryId = 4,
								ProductInfos = new List<ProductInfo>()
								{
									new ProductInfo { Info ="Item weight : 450 Grams" },
									 new ProductInfo { Info ="Sensor type : CMOS (APS-C) " }
								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "CanonEOS250D"+1+".jpg"},
									new Image { ImageUrl = "CanonEOS250D"+2+".jpg"},
									new Image { ImageUrl = "CanonEOS250D"+3+".jpg"},
									new Image { ImageUrl = "CanonEOS250D"+4+".jpg"}

								}
					   },

                        new Product{
                                Name = "Sony Alpha ZV-E10L",
                                Price = 34000,
                                Color = (int)ProductColors.Black,
                                Description = "Efficient light collection for high-quality images with minimal noise: The ZV-E10's large-format image sensor is designed to maximise light collection \r\n Precise focus transitions for smooth-looking product reviews: With just the press of a button",
                                RealseDate = new DateTime(2020,07,22),
                                UnitsInStock = 5,
                                OutOfStock = 0,
                                BrandId = 8,
                                CategoryId = 4,
                                ProductInfos = new List<ProductInfo>()
                                {
                                    new ProductInfo { Info ="Item weight : 364 Grams" },
                                     new ProductInfo { Info ="Sensor type : (APS-C) " }
                                },
                                Images = new List<Image>()
                                {
                                    new Image { ImageUrl = "SonyAlphaZVE10L"+1+".jpg"},
                                    new Image { ImageUrl = "SonyAlphaZVE10L"+2+".jpg"},
                                    new Image { ImageUrl = "SonyAlphaZVE10L"+3+".jpg"},
                                    new Image { ImageUrl = "SonyAlphaZVE10L"+4+".jpg"}

                                }
                        },

                         new Product{
								Name = "Canon 1897C003Aa",
								Price = 50000,
								Color = (int)ProductColors.Black,
								Description = "Full HD Video at 60 fps; Digital IS\r\n 45-Point All-Cross Type AF System\r\n ISO Sensitivity Auto, 100-40000 (Extended Mode: 50-102400)  ",
								RealseDate = new DateTime(2022,11,29),
								UnitsInStock = 5,
								OutOfStock = 0,
								BrandId = 12,
								CategoryId = 4,
								ProductInfos = new List<ProductInfo>()
								{
									new ProductInfo { Info ="Item weight : 685 Grams" },
									 new ProductInfo { Info ="Sensor type : CMOS (APS-C) " }
								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "Canon1897C003Aa"+1+".jpg"},
									new Image { ImageUrl = "Canon1897C003Aa"+2+".jpg"},
									new Image { ImageUrl = "Canon1897C003Aa"+3+".jpg"},
									new Image { ImageUrl = "Canon1897C003Aa"+4+".jpg"}

								},
                                Sale=5
					   },

							 new Product{
								Name = "Fujifilm X-T30",
								Price = 38999,
								Color = (int)ProductColors.Black,
								Description = "Updated AF-Algorithm & improved face and eye tracking\r\n High resolution digital sound recording\r\n White balance includes Automatic Scene recognition, Custom1-3, Color temperature selection (2500K-10000K)",
								RealseDate = new DateTime(2021,10,27),
                                Sale=5,
                                UnitsInStock = 5,
								OutOfStock = 0,
								BrandId = 12,
								CategoryId = 4,
								ProductInfos = new List<ProductInfo>()
								{
									new ProductInfo { Info ="Item weight : 383 Grams" },
									 new ProductInfo { Info ="Sensor type : X-Trans CMOS 4 " }
								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "FujifilmXT30"+1+".jpg"},
									new Image { ImageUrl = "FujifilmXT30"+2+".jpg"},
									new Image { ImageUrl = "FujifilmXT30"+3+".jpg"},
									new Image { ImageUrl = "FujifilmXT30"+4+".jpg"}

								}
							 },

							  new Product{
								Name = "Nikon Z 6ii",
								Price = 102999,
								Color = (int)ProductColors.Black,
								Description = "14 fps /dual memory slots (cfexpress/xqd and sd cards)\r\n 273-point hybrid autofocus system\r\n 245mp bsi (full frame) / 4k video.",
								RealseDate = new DateTime(2021,10,27),
                                Sale=5,
                                UnitsInStock = 5,
								OutOfStock = 0,
								BrandId = 8,
								CategoryId = 4,
								ProductInfos = new List<ProductInfo>()
								{
									new ProductInfo { Info ="Item weight : 702 Grams" },
									 new ProductInfo { Info ="Sensor type : BSI CMOS" }
								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "NikonZ6ii"+1+".jpg"},
									new Image { ImageUrl = "NikonZ6ii"+2+".jpg"},
									new Image { ImageUrl = "NikonZ6ii"+3+".jpg"},
									new Image { ImageUrl = "NikonZ6ii"+4+".jpg"}

								}
							  },

							  new Product{
								Name = " IPhone 12",
								Price = 419.99,
								Color = (int)ProductColors.Purple,
								Description = "Product works and looks like new. Backed by the 90-day Amazon Renewed Guarantee.\r\n",
								RealseDate = new DateTime(2019,3,27),
								UnitsInStock = 10,
								OutOfStock =4,
								BrandId = 5,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :iPhone 12\r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : AT&T\r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :256 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 6.1 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n : WIFI \r\n" },
									 new ProductInfo { Info ="OS\r\n :IOS \r\n" }

								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "iphone12"+1+".jpg"},
									new Image { ImageUrl = "iphone12"+2+".jpg"},
									new Image { ImageUrl = "iphone12"+3+".jpg"},


								}

							 },

							  new Product{
								Name = "IPhone 12 Pro",
								Price = 444.99,
								Color = (int)ProductColors.Red,
								Description = "The product is refurbished, fully functional, and in excellent condition. Backed by the 90-day Amazon Renewed Guarantee.\r\n",
								RealseDate = new DateTime(2019,6,27),
								UnitsInStock =8,
								OutOfStock =6,
								BrandId = 5,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :iPhone 12 pro\r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : Unlocked\r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :256 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 6.1 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n : WIFI \r\n" },
									 new ProductInfo { Info ="OS\r\n :IOS \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "iphone12pro"+1+".jpg"},
									new Image { ImageUrl = "iphone12pro"+2+".jpg"},
									new Image { ImageUrl = "iphone12pro"+3+".jpeg"},


								}

							 },

							  new Product{
								Name = "IPhone 13 Pro",
								Price = 789.99,
								Color = (int)ProductColors.Graphite,
                                Description = "The product is refurbished, fully functional, and in excellent condition. Backed by the 90-day Amazon Renewed Guarantee.\r\n",
								RealseDate = new DateTime(2021,4,22),
                                Sale=5,
                                UnitsInStock =20,
								OutOfStock =7,
								BrandId = 5,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :iPhone 13 pro\r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : AT&T\r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :128 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 6.1 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n : WIFI \r\n" },
									 new ProductInfo { Info ="OS\r\n :IOS \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "iphone13pro"+1+".jpg"},
									new Image { ImageUrl = "iphone13pro"+2+".jpg"},
									new Image { ImageUrl = "iphone13pro"+3+".jpg"},
									new Image { ImageUrl = "iphone13pro"+4+".jpg"}


								}

							 },

						   new Product{
								Name = "IPhone 14",
								Price = 703.92,
								Color = (int)ProductColors.Starlight,
                                Description = "The product is refurbished, fully functional, and in excellent condition. Backed by the 90-day Amazon Renewed Guarantee.\r\n",
								RealseDate = new DateTime(2021,4,22),
                                Sale=1,
                                UnitsInStock =20,
								OutOfStock =7,
								BrandId = 5,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :iPhone 14\r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : AT&T\r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :128 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 6.1 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n : WIFI \r\n" },
									 new ProductInfo { Info ="OS\r\n :IOS \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "iphone14"+1+".jpg"},
									new Image { ImageUrl = "iphone14"+2+".jpg"},
									new Image { ImageUrl = "iphone14"+3+".jpg"},
									new Image { ImageUrl = "iphone14"+4+".jpg"}


								}

						  },

							new Product{
								Name = "IPhone SE",
								Price = 226.00,
								Color = (int)ProductColors.Red,                               
                                Description = "A like-new experience. Backed by a one-year satisfaction guarantee.\r\n",
								RealseDate = new DateTime(2016,4,22),
								UnitsInStock =20,
								OutOfStock =5,
								BrandId = 5,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :IPhone SE\r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : Unlocked for All Carriers\r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :64 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 4.7 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n :USB\r\n" },

									 new ProductInfo { Info ="OS\r\n :iOS 13 \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "iphoneSe"+1+".jpg"},
									new Image { ImageUrl = "iphoneSe"+2+".jpg"},
									new Image { ImageUrl = "iphoneSe"+3+".jpg"}

								}

							 },

							 new Product{
								Name = "IPhone X\r\n",
								Price = 244.99,
								Color = (int)ProductColors.Silver,
								Description = "The product is refurbished, fully functional, and in excellent condition. Backed by the 90-day Amazon Renewed Guarantee.\r\n",
								RealseDate = new DateTime(2018,6,2),
								UnitsInStock =40,
								OutOfStock =10,
								BrandId = 5,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :IPhone X\r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : Unlocked \r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :256 GB\r\n\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 5.9 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n :GSM, CDMA\r\n" },
									 new ProductInfo { Info ="OS\r\n :iOS \r\n" }
								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "iphonex"+1+".jpg"},
									new Image { ImageUrl = "iphonex"+2+".jpg"}
								}

							 },

							  new Product{
								Name = "IPhone Xs\r\n",
								Price = 298.00,
								Color = (int)ProductColors.SPACEGRAY,
								Description = "A like-new experience. Backed by a one-year satisfaction guarantee.\r\n",
								RealseDate = new DateTime(2018,7,2),
								UnitsInStock =30,
								OutOfStock =15,
								BrandId = 5,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :IPhone Xs\r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : Unlocked for All Carriers\r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :256 GB\r\n\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 5.9 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n :GSM, CDMA\r\n" },
									 new ProductInfo { Info ="OS\r\n :iOS \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "iphonexs"+1+".jpg"}

								}

							 },

							 new Product{
								Name = "Samsung Galaxy S10 \r\n",
								Price = 171.29,
								Color = (int)ProductColors.Blue,

								Description = "The product is refurbished, fully functional, and in excellent condition. Backed by the 90-day Amazon Renewed Guarantee.\r\n",
								RealseDate = new DateTime(2018,6,2),
								UnitsInStock =10,
								OutOfStock =4,
								BrandId = 1,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :Samsung Galaxy S10 \r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : Unlocked \r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :128 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 6.1 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n :GSM\r\n" },
									 new ProductInfo { Info ="OS\r\n :Android 9.0 \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "samsungGalaxys10"+1+".jpg"},
									new Image { ImageUrl = "samsungGalaxys10"+2+".jpg"},


								}

							 },

							  new Product{
								Name = "Samsung Galaxy S22 \r\n",
								Price = 999.99,
								Color = (int)ProductColors.Green,
								Description = "Factory Unlocked Android Smartphone, 128GB, 8K Camera \r\n  Video, Brightest Display Screen, S Pen, Long Battery Life, Fast 4nm Processor \r\nUS Version, Green \r\n",
								RealseDate = new DateTime(2018,6,2),
								UnitsInStock =10,
								OutOfStock =4,
								BrandId = 1,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :Samsung Galaxy S22 \r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : Unlocked \r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :128 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 6.8 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n :GSM, CDMA, LTE\r\n" },
									 new ProductInfo { Info ="OS\r\n :Android 12.0 \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "samsungGalaxys22"+1+".jpg"},
									new Image { ImageUrl = "samsungGalaxys22"+2+".jpg"},
									new Image { ImageUrl = "samsungGalaxys22"+3+".jpg"}
								}

							 },

							 new Product{
								Name = "Samsung Galaxy Z \r\n",
								Price = 1449,
								Color = (int)ProductColors.Beige,
								Description = "Factory Unlocked Android Smartphone \r\n  256GB, Flex Mode, Hands Free Video, Multi Window View, Foldable Display, S Pen Compatible, US Version, Beige \r\n",
								RealseDate = new DateTime(2018,6,2),
								UnitsInStock =10,
								OutOfStock =4,
								BrandId = 1,
								CategoryId = 1,
								ProductInfos = new List<ProductInfo>()
								{
									 new ProductInfo { Info ="Model Name\r\n :Samsung Galaxy Z \r\n" },
									 new ProductInfo { Info ="Wireless Carrier\r\n : Unlocked \r\n" },
									 new ProductInfo { Info ="Memory Storage Capacity\r\n :128 GB\r\n" },
									 new ProductInfo { Info ="Screen Size\r\n : 6.8 Inches\r\n" },
									 new ProductInfo { Info ="Wireless network technology\r\n :GSM, CDMA, LTE\r\n" },
									 new ProductInfo { Info ="OS\r\n :Android \r\n" }


								},
								Images = new List<Image>()
								{
									new Image { ImageUrl = "samsungGalaxyZ"+1+".jpg"},
									new Image { ImageUrl = "samsungGalaxyZ"+2+".jpg"},
									new Image { ImageUrl = "samsungGalaxyZ"+3+".jpg"}
								}

							 },
				});
				context.SaveChanges();

			}


        }
    }
}
