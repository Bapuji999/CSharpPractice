using Microsoft.EntityFrameworkCore;
using Project_4.Models;
using System.Text;

namespace Project_4
{
    class AdminDashboard
    {
        public static void AdminDashboardPage()
        {
            try
            {
                Contex _contex = new Contex();
                var totalVehicles = _contex.Vehicle.Where(x => x.IsDeleted == false).Count();
                var totalVehicleOnRent = _contex.Vehicle.Where(x => x.isAvailable == false).Count();
                var totalUser = _contex.User.Where(x => x.IsDeleted == false && x.IsAdmin == false).Count();
                var totalPaymentRecived = _contex.PaymentDetails.Select(x => x.TotalPayment).Sum();

                Console.WriteLine($"Total Vehicles: {totalVehicles}");
                Console.WriteLine($"Total Vehicle On Rent: {totalVehicleOnRent}");
                Console.WriteLine($"Total User: {totalUser}");
                Console.WriteLine($"Total Payment Recived: {totalPaymentRecived}");

                StringBuilder options = new StringBuilder();
                options.AppendLine("Plese choose a Option.");
                options.AppendLine("1. Add Vehicle");
                options.AppendLine("2. Vehicle List");
                options.AppendLine("3. Add User");
                options.AppendLine("4. User List");
                options.AppendLine("5. Rent Vehicle");
                options.AppendLine("6. Vehicle Rented List");
                options.AppendLine("7. Return Vehicle");
                options.AppendLine("8. Payment Detail");
                Console.WriteLine(options);

                int selectedOption;
                int.TryParse(Console.ReadLine(), out selectedOption);
                switch (selectedOption)
                {
                    case 1:
                        AddVehicle(_contex);
                        break;
                    case 2:
                        listVehicle(_contex);
                        AdminDashboardPage();
                        break;
                    case 3:
                        addUser(_contex);
                        break;
                    case 4:
                        listUser(_contex);
                        AdminDashboardPage();
                        break;
                    case 5:
                        rentVehicle(_contex);
                        AdminDashboardPage();
                        break;
                    case 6:
                        listVehicleRented(_contex);
                        AdminDashboardPage();
                        break;
                    case 7:
                        returnVehicle(_contex);
                        AdminDashboardPage();
                        break;
                    case 8:
                        showPaymentDetails(_contex);
                        AdminDashboardPage();
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        AdminDashboardPage();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void AddVehicle(Contex _contex)
        {
            try
            {
                Vehicle vehicle = new Vehicle();
                Console.WriteLine("Enter VehicleNo");
                var vehicleNo = Console.ReadLine();
                validateVehicleNo(vehicleNo, vehicle, _contex);
                Console.WriteLine("Enter VehicleName");
                vehicle.VehicleName = Console.ReadLine();
                Console.WriteLine("Enter Brand");
                vehicle.Brand = Console.ReadLine();
                Console.WriteLine("Select Vehicle type: ");
                printVehicleTypeOptions(_contex);
                int selectdType;
                int.TryParse(Console.ReadLine(), out selectdType);
                vehicle.VehicleTypeId = selectdType;
                Console.WriteLine("Enter PerDayPrice");
                double perDayPrice;
                double.TryParse(Console.ReadLine(), out perDayPrice);
                vehicle.PerDayPrice = perDayPrice;
                _contex.Add(vehicle);
                _contex.SaveChanges();
                Console.WriteLine("Vehicle sucessfully added.");
                AdminDashboardPage();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void validateVehicleNo(string vehicleNo, Vehicle vehicle, Contex _contex)
        {
            try
            {
                var isAlreadyExist = _contex.Vehicle.Any(x => x.VehicleNo == vehicleNo);
                if (isAlreadyExist)
                {
                    Console.WriteLine("Vehicle already exist please enter another vehicle");
                    Console.WriteLine("Enter VehicleNo");
                    vehicleNo = Console.ReadLine();
                    validateVehicleNo(vehicleNo, vehicle, _contex);
                }
                else
                {
                    vehicle.VehicleNo = vehicleNo;
                    return;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void printVehicleTypeOptions(Contex _contex)
        {
            try 
            {
                var vehicleTypes = _contex.VehicleType.ToList();
                foreach (var vehicleType in vehicleTypes)
                {
                    Console.WriteLine($"{vehicleType.VehicleTypeId}. {vehicleType.VehicleTypeName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void listVehicle(Contex _contex)
        {
            try
            {
                var allVehicles = _contex.Vehicle.Where(x => x.IsDeleted == false).ToList();
                var allType = _contex.VehicleType.ToList();
                Console.WriteLine("Vehicle List:\n");
                int index = 1;
                foreach (var vehicle in allVehicles)
                {
                    string avalability = vehicle.isAvailable ? "Available" : "Not Available";
                    var type = allType.Where(x => x.VehicleTypeId == vehicle.VehicleTypeId).Select(x => x.VehicleTypeName).First();
                    Console.WriteLine($"{index}. Id: {vehicle.VehicleId}, VehicleName: {vehicle.VehicleName}, Brand: {vehicle.Brand}, Type: {type}, Avalabilty: {avalability}");
                    index++;
                }
                Console.WriteLine();
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void addUser(Contex _contex)
        {
            try
            {
                User user = new User();
                Console.WriteLine("Enter UserName:");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                string email = Console.ReadLine();
                Program.IsValidEmail(email, user);
                Console.WriteLine("Enter Phone:");
                string phone = Console.ReadLine();
                Program.IsValidPhoneNumber(phone, user);
                Console.WriteLine("Enter Password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Enter LicenceNo");
                user.LicenceNo = Console.ReadLine();
                Console.WriteLine("Select User Type; \n1.Gold\n2.Silver\n3.Platinum");
                int userType;
                int.TryParse(Console.ReadLine(), out userType);
                user.UserTypeId = userType;
                _contex.Add(user);
                _contex.SaveChanges();
                Console.WriteLine("User aded Sucessfully");
                AdminDashboardPage();
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void listUser(Contex _contex)
        {
            try
            {
                var allUsers = _contex.User.Where(x => x.IsDeleted == false && x.IsAdmin == false).ToList();
                var allType = _contex.UserType.ToList();
                Console.WriteLine("User List:\n");
                int index = 1;
                foreach (var user in allUsers)
                {
                    var type = allType.Where(x => x.UserTypeId == user.UserTypeId).Select(x => x.UserTypeName).First();
                    Console.WriteLine($"{index}. Id: {user.UserId}, Name: {user.UserName}, Email: {user.Email}, Phone: {user.Phone}, LicenceNo: {user.LicenceNo}, Type: {type}");
                    index++;
                }
                Console.WriteLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void rentVehicle(Contex _contex)
        {
            try
            {
                VehicleIssue vehicleIssue = new VehicleIssue();
                Console.WriteLine("Select Vehicle Id: ");
                int id;
                userIdCheck(_contex, vehicleIssue, out id);
                int vehicleId;
                vehicleIdCheck(_contex, vehicleIssue, out vehicleId);
                vehicleIssue.IssueDate = DateTime.Now;
                deliveryDateCheck(vehicleIssue);
                dueDateDateCheck(vehicleIssue);

                PaymentDetails paymentDetails = new PaymentDetails();
                var totaldays = (vehicleIssue.DueDate - vehicleIssue.DeliveryDate).Days;
                var perDayPrice = _contex.Vehicle.Where(x => x.VehicleId == vehicleId).Select(x => x.PerDayPrice).First();
                var totalRent = totaldays * perDayPrice;
                paymentDetails.TotalRent = totalRent;

                advanceCheck(totalRent, paymentDetails);
                _contex.Add(vehicleIssue);
                _contex.SaveChanges();
                paymentDetails.VehicleIssueId = _contex.VehicleIssue.Where(x => x.VehicleId == vehicleId && x.UserId == id && x.IssueDate == vehicleIssue.IssueDate).Select(x => x.VehicleIssueId).First();
                _contex.Add(paymentDetails);
                var vehicle = _contex.Vehicle.Where(x => x.VehicleId == vehicleId).First();
                vehicle.isAvailable = false;
                _contex.Update(vehicle);
                _contex.SaveChanges();
                Console.WriteLine("Vehicle Issued.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void listVehicleRented(Contex _contex)
        {
            try
            {
                var vehiclesRented = _contex.VehicleIssue
                                            .Include(vi => vi.vehicle)
                                            .Include(vi => vi.User)
                                            .Where(vi => vi.ReturnDate == null);
                int index = 1;
                Console.WriteLine("Vehicle Rented List:\n");
                foreach (var vehicleRented in vehiclesRented)
                {
                    User? user = vehicleRented.User;
                    Vehicle? vehicle = vehicleRented.vehicle;
                    Console.WriteLine($"{index}. IssueId: {vehicleRented.VehicleIssueId}, VehicleName: {vehicle?.VehicleName}, VehicleNumber: {vehicle?.VehicleNo}, User: {user?.UserName}");
                }
                Console.WriteLine();
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void returnVehicle(Contex _contex)
        {
            try
            {
                Console.WriteLine("Please Enter UserId: ");
                int userId;
                int.TryParse(Console.ReadLine(), out  userId);
                Console.WriteLine("Please Enter VehicleId: ");
                int vehicleId;
                int.TryParse(Console.ReadLine(), out vehicleId);
                var vehicleIssue = _contex.VehicleIssue
                                          .Include(vi => vi.vehicle)
                                          .Include(vi => vi.PaymentDetails)
                                          .Where(vi => vi.VehicleId == vehicleId && vi.UserId == userId)
                                          .FirstOrDefault();
                vehicleIssue.ReturnDate = DateTime.Now;
                if(vehicleIssue.ReturnDate < vehicleIssue.DueDate)
                {
                    Console.WriteLine("Vehicle not reliesed till now.");
                    return;
                }
                int? totalDays = (vehicleIssue.ReturnDate - vehicleIssue.DeliveryDate)?.Days;
                int? extaDays = vehicleIssue.DueDate < vehicleIssue.ReturnDate ? (vehicleIssue.ReturnDate - vehicleIssue.DueDate)?.Days : 0;
                double? totalPayment = (totalDays * vehicleIssue?.vehicle?.PerDayPrice) + (extaDays * 500) - vehicleIssue.PaymentDetails.TotalPayment;
                Console.WriteLine($"Please pay {totalPayment}");
                double payAmount;
                double.TryParse(Console.ReadLine(), out payAmount);
                double? total = totalPayment;
                while (total != 0)
                {
                    if (payAmount < total)
                    {
                        total = total - payAmount;
                        Console.WriteLine($"Please pay remaining {total}");
                        double.TryParse(Console.ReadLine(), out payAmount);
                    }
                    if (payAmount > total)
                    {
                        var change = payAmount - total;
                        total = 0;
                        Console.WriteLine($"Please take change {change}");
                    }
                    else
                    {
                        total = 0;
                    }
                }
                vehicleIssue.PaymentDetails.TotalPayment = (double)totalPayment;
                vehicleIssue.PaymentDetails.IsFullPaymentDone = true;
                vehicleIssue.vehicle.isAvailable = true;
                _contex.Update(vehicleIssue);
                _contex.SaveChanges();
                Console.WriteLine("Return Sucessfull");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void showPaymentDetails(Contex _contex)
        {
            Console.WriteLine("Please Enter UserId: ");
            int userId;
            int.TryParse(Console.ReadLine(), out userId);
            Console.WriteLine("Please Enter VehicleId: ");
            int vehicleId;
            int.TryParse(Console.ReadLine(), out vehicleId);
            var vehicleIssueDetails = _contex.VehicleIssue
                                             .Include(vi => vi.PaymentDetails)
                                             .Where(vi => vi.UserId == userId && vi.VehicleId == vehicleId);
            if (!vehicleIssueDetails.Any())
            {
                Console.WriteLine("No Payment details is there for specified input.");
                return;
            }
            Console.WriteLine("Please select the issueDate.");
            foreach( var vehicle in vehicleIssueDetails )
            {
                Console.WriteLine($"{vehicle.VehicleIssueId}. {vehicle.IssueDate}");
            }
            int selected;
            int.TryParse(Console.ReadLine(), out selected);
            while(!vehicleIssueDetails.Any(vi => vi.VehicleIssueId == selected))
            {
                Console.WriteLine("Please select from the above options.");
                int.TryParse(Console.ReadLine(), out selected);
            }
            var vehicleIssueDetail = vehicleIssueDetails.Where(vi => vi.VehicleIssueId == selected).FirstOrDefault();
            var paymentDetails = vehicleIssueDetail.PaymentDetails;
            int? extaDays = vehicleIssueDetail.DueDate < vehicleIssueDetail.ReturnDate ? (vehicleIssueDetail.ReturnDate - vehicleIssueDetail.DueDate)?.Days : 0;
            var totalFine = extaDays * 500;
            var totalRent = vehicleIssueDetail.ReturnDate == null ? paymentDetails.TotalRent : paymentDetails.TotalPayment - totalFine;
            Console.WriteLine($"Total Payment: {paymentDetails.TotalPayment}, Total Rent: {totalRent}, Total Fine: {totalFine}");                                        
        }
        static void listAvailableVehicle(Contex _contex)
        {

            try
            {
                var allVehicles = _contex.Vehicle.Where(x => x.IsDeleted == false && x.isAvailable == true).ToList();
                var allType = _contex.VehicleType.ToList();
                Console.WriteLine("Vehicle List:\n");
                int index = 1;
                foreach (var vehicle in allVehicles)
                {
                    string avalability = vehicle.isAvailable ? "Available" : "Not Available";
                    var type = allType.Where(x => x.VehicleTypeId == vehicle.VehicleTypeId).Select(x => x.VehicleTypeName).First();
                    Console.WriteLine($"{index}. Id: {vehicle.VehicleId}, VehicleName: {vehicle.VehicleName}, Brand: {vehicle.Brand}, Type: {type}, Avalabilty: {avalability}");
                    index++;
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void vehicleIdCheck(Contex _contex, VehicleIssue vehicleIssue, out int vehicleId)
        {
            vehicleId = 0;
            try
            {
                Console.WriteLine("Select Vehicle Id: ");
                listAvailableVehicle(_contex);
                int.TryParse(Console.ReadLine(), out vehicleId);
                int xId = vehicleId;
                if (_contex.Vehicle.Where(x => x.IsDeleted == false && x.isAvailable == true).Any(x => x.VehicleId == xId))
                {
                    vehicleIssue.VehicleId = vehicleId;
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid User Id Plese try again.");
                    vehicleIdCheck(_contex, vehicleIssue, out vehicleId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void userIdCheck(Contex _contex, VehicleIssue vehicleIssue, out int id)
        {
            id = 0;
            try
            {
                Console.WriteLine("Select User Id: ");
                listUser(_contex);
                int.TryParse(Console.ReadLine(), out id);
                int xId = id;
                if(_contex.User.Where(x => x.IsDeleted == false && x.IsAdmin == false).Any(x => x.UserId == xId))
                {
                    vehicleIssue.UserId = id;
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid User Id Plese try again.");
                    userIdCheck(_contex, vehicleIssue, out id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void deliveryDateCheck(VehicleIssue vehicleIssue)
        {
            try
            {
                Console.WriteLine("Enter DeliveryDate(yyyy-MM-dd): ");
                string userInput = Console.ReadLine();
                if (DateTime.TryParseExact(userInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    if(result < vehicleIssue.IssueDate)
                    {
                        Console.WriteLine("DeliveryDate can not less than the Issue-Date");
                        deliveryDateCheck(vehicleIssue);
                    }
                    else
                    {
                        vehicleIssue.DeliveryDate = result;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter in the correct format (yyyy-MM-dd).");
                    deliveryDateCheck(vehicleIssue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void dueDateDateCheck(VehicleIssue vehicleIssue)
        {
            try
            {
                Console.WriteLine("Enter DueDateDate(yyyy-MM-dd): ");
                string userInput = Console.ReadLine();
                if (DateTime.TryParseExact(userInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    if (result < vehicleIssue.DeliveryDate)
                    {
                        Console.WriteLine("DueDateDate can not less than the DeliveryDate");
                        dueDateDateCheck(vehicleIssue);
                    }
                    else
                    {
                        vehicleIssue.DueDate = result;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter in the correct format (yyyy-MM-dd).");
                    dueDateDateCheck(vehicleIssue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void returnDateDateCheck(VehicleIssue vehicleIssue)
        {
            try
            {
                Console.WriteLine("Enter ReturnDateDate(yyyy-MM-dd): ");
                string userInput = Console.ReadLine();
                if (DateTime.TryParseExact(userInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    if (result < vehicleIssue.DeliveryDate)
                    {
                        Console.WriteLine("ReturnDateDate can not less than the DeliveryDate");
                        returnDateDateCheck(vehicleIssue);
                    }
                    else
                    {
                        vehicleIssue.ReturnDate = result;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter in the correct format (yyyy-MM-dd).");
                    returnDateDateCheck(vehicleIssue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        static void advanceCheck(double totalRent, PaymentDetails paymentDetails)
        {
            try
            {
                Console.WriteLine("Enter Advance Payment Amount: ");
                double advance;
                double.TryParse(Console.ReadLine(), out advance);
                if (advance < 0 || advance > totalRent)
                {
                    Console.WriteLine("Please Enter a Valid amount");
                    advanceCheck(totalRent, paymentDetails);
                }
                if (advance == 0)
                {
                    return;
                }
                else
                {
                    paymentDetails.TotalPayment = advance;
                    paymentDetails.IsAdvancePaymentDone = true;
                    return;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
