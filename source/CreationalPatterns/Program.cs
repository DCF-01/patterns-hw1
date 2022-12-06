using CreationalPatterns;
using CreationalPatterns.Services;

//we create a typed factory with the generic type being PackageBase 
var factory = new PackageFactory<BasePackage>();

const string sp1Name = "post-paid";
const string sp2Name = "pre-paid";

//we create service packages as wrappers which contain the services themselves   
var sp1 = new ServicePackage(sp1Name);
var sp2 = new ServicePackage(sp2Name);

//we add the services to the service packages
var dataSvc = new DataService(100M, 20M, 5, 2000, 2000);
sp1.Add(dataSvc);
sp1.Add(new VoiceService(100M, 20M, 100, 2));
sp1.Add(new SmsService(20M, 15M, 100, 90));

sp2.Add(new DataService(20M, 15M, 5, 90, 40));
sp2.Add(new VoiceService(15M, 5M, 200, 4));

//add the packages to the managing factory
factory.Add(sp1);
factory.Add(sp2);

//print results to console
Console.WriteLine("Service Package 1");
sp1.ListServices(1);
Console.WriteLine("Service Package 2");
sp2.ListServices(1);

//clone a service, and check if result is identical to original object
var sp3 = factory.FindAndClone(sp1Name);
//change sms service value and check results
dataSvc.MaxDl = 5;
dataSvc.MaxUp = 2;

factory.Add(sp3);

//list service 1 and 3 to see if only the 3rd changes
//the result has change for sp1 as we changed its properties above
Console.WriteLine("ServicePackage 1 has changed pricing due to changes to Maxdl and Maxup");
sp1.ListServices(1);

//check cloned object result
//sp3 will have the same result
//as the original sp1 as the value types were copied from it
Console.WriteLine("ServicePackage 3 is the same as the object it was cloned from (ServicePackage 1)");
sp3.ListServices(1);

//we try to add 2 data service objects
//if the service package contains a svc of that Type
//it will not be added
//only unique services are added
sp2.Add(dataSvc);
sp2.Add(dataSvc);
//no changes in service package 2
sp2.ListServices(1);

//we dont keep Ids, so we only remove and add services based on Type
sp2.Remove(typeof(DataService));
//service package 2 now only contains the voice service
Console.WriteLine("Service Package 2");
sp2.ListServices(1);

