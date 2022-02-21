import csv
import PySimpleGUI as sg



# Very Basic GUI File Chooser (Props to PySimpleGUI CookBook)
sg.theme('Light Blue 2')

layout = [[sg.Text('Please Enter both .csv files from the surveys')],
          [sg.Text('Do not forget to replace all commas in the .csv files with an underscore "_"')],
          [sg.Text('Student Survey File', size=(15, 1)), sg.Input(), sg.FileBrowse()],
          [sg.Text('Director Survey File', size=(15, 1)), sg.Input(), sg.FileBrowse()],
          [sg.Submit(), sg.Cancel()]]

window = sg.Window('File Selector', layout)

event, values = window.read()
window.close()

WorkerInfo = values[0]
HourOptions = values[1]
################


class Worker:  #Class that holds worker info
    def __init__(self, Name, Year, Field_Of_Study, Hours_Wanted, Times_Available):
      self.Name = Name                           ##Single Value
      self.Year = Year                           ##Single Value
      self.Hours_Wanted = int(Hours_Wanted)      ##Single Value
      self.Field_Of_Study = Field_Of_Study       ##List
      self.Times_Available = Times_Available     ##List
      self.NumberOfShifts = 0 ##List
BlankWorker = Worker("-1", "", [],0, [])

class WorkShift:  #Class that holds Shift info
    def __init__(self, hour, priority):
      self.hour = hour                         ##Single Value
      self.priority = priority                 ##Single Value
      self.workerNames = []                    ##List

    
################################## Start of Main Program ################################
def Main():
    print(WorkerInfo)
    if(WorkerInfo != "" and HourOptions != ""):
        WorkersList=CreateWorkerList()
        Hour_OptionsList, Choices_List=CreateHourList()
        #                                                    #Done                 #Done
        #Choices_List = [MULTIPLE_SHIFTS,MIX_MAJORS,MIX_AGES,SHIFT_MINIMUM_WORKERS,SHIFT_MAXIMUM_WORKERS]//Need to imlement


        for worker in WorkersList: #Workers get distributed to all available work times
            for TimeAvailable in worker.Times_Available:
                for Shift in Hour_OptionsList:
                    if TimeAvailable == Shift.hour:
                        Shift.workerNames.append(worker)
                        worker.NumberOfShifts+=1
                
        for Shift in range(len(Hour_OptionsList)):##Tries to reduce under SHIFT_MAXIMUM_WORKERS
            ScheduleTrimmer1(Hour_OptionsList,Shift,Choices_List[4],True,Choices_List[0],Choices_List[1],Choices_List[2])
                
        priority = 3
        while (priority>=1):#Tries to reduce to SHIFT_MINIMUM_WORKERS using priority
            for Shift in range(len(Hour_OptionsList)):
                if Hour_OptionsList[Shift].priority == priority:
                    ScheduleTrimmer1(Hour_OptionsList,Shift,Choices_List[3],False,Choices_List[0],Choices_List[1],Choices_List[2])
            priority-=1
    
        CreateOutputFile (Hour_OptionsList,WorkersList)#Creates the "Schedule.csv" file
        PrintErrorReport(Hour_OptionsList,WorkersList,Choices_List[4],Choices_List[3])#Prints Efficiencies to Shell
    else:
        print("ERROR: Please choose two files")
################################## End of Main Program ###################################


def CreateWorkerList():#modified DONE
    global WorkerInfo
    WorkersList=[]
    WorkerNames=[]#Used to stop multiple signups by same person


    with open (WorkerInfo, "r", encoding='utf-8') as WorkerInfo:
        WorkerInfo.readline()
        for line in WorkerInfo:
            timeStamp, email, firstName, lastName, year, field_Of_Study, hoursTens, hoursSingles, sunday, monday, tuesday, wednesday, thursday, friday, saturday=line.split(",")

            name = firstName.strip() + " " + lastName.strip()
            #print(name)
            year = year.strip()

            field_Of_Study = field_Of_Study.strip()
            TempFieldStudyList=[i.strip() for i in field_Of_Study.split("_")]

            hoursWanted=(int(hoursTens.strip())*10)+int(hoursSingles.strip())

            week = [sunday, monday, tuesday, wednesday, thursday, friday, saturday]
            weekNames = ["sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday"]

            TempTimesAvailableList = []
            for i in range(len(week)):
                week[i] = week[i].strip()

                PreTempTimesAvailableList=[weekNames[i]+time.strip() for time in week[i].split("_")]


                for index in range(len(PreTempTimesAvailableList)):
                    if "->" in PreTempTimesAvailableList[index]:
                        TempTimesAvailableList.append(PreTempTimesAvailableList[index])
                       # print(PreTempTimesAvailableList[index])

            TempWorker = Worker(name, year, TempFieldStudyList, hoursWanted, TempTimesAvailableList)
            if TempWorker.Name not in WorkerNames:
                WorkersList.append(TempWorker)
                WorkerNames.append(TempWorker.Name)
        WorkerInfo.close()
    return (WorkersList)

  
def CreateHourList():#modified DONE
   global HourOptions
   Hour_OptionsList=[]
   with open (HourOptions, "r", encoding='utf-8') as HourOptions:
      HourOptions.readline()
      for line in HourOptions:

        time_stamp, director_email, multiple_shifts, mix_majors, mix_age, min_ten, min_single, max_ten, max_single, o_sunday, o_monday, o_tuesday, o_wednesday, o_thursday, o_friday, o_saturday, b_sunday, b_monday, b_tuesday, b_wednesday, b_thursday, b_friday, b_saturday, l_sunday, l_monday, l_tuesday, l_wednesday, l_thursday, l_friday, l_saturday = line.split(",")

        MULTIPLE_SHIFTS = (multiple_shifts.strip() != "No")
        MIX_MAJORS = (mix_majors.strip() == "Yes")
        MIX_AGES = (mix_age.strip() == "Yes")

        SHIFT_MINIMUM_WORKERS = (int(min_ten.strip())*10) + int(min_single.strip())
        SHIFT_MAXIMUM_WORKERS = (int(max_ten.strip())*10) + int(max_single.strip())

        Choices_List = [MULTIPLE_SHIFTS,MIX_MAJORS,MIX_AGES,SHIFT_MINIMUM_WORKERS,SHIFT_MAXIMUM_WORKERS]

        weekNames = ["sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday"]
        o_week = [o_sunday, o_monday, o_tuesday, o_wednesday, o_thursday, o_friday, o_saturday]
        b_week = [b_sunday, b_monday, b_tuesday, b_wednesday, b_thursday, b_friday, b_saturday]
        l_week = [l_sunday, l_monday, l_tuesday, l_wednesday, l_thursday, l_friday, l_saturday]

        for i in range(len(o_week)):
            o_week[i] = o_week[i].strip().split("_")
            b_week[i] = b_week[i].strip().split("_")
            l_week[i] = l_week[i].strip().split("_")

            for time in range(len(o_week[i])):
                #print(weekNames[i]+o_week[i][time])

                if o_week[i][time].strip() != "":
                    if o_week[i][time] in b_week[i]:
                      TempHour = WorkShift(weekNames[i]+o_week[i][time].strip(), 1)
                    elif o_week[i][time] in l_week[i]:
                      TempHour = WorkShift(weekNames[i]+o_week[i][time].strip(), 3)
                    else:
                     TempHour = WorkShift(weekNames[i]+o_week[i][time].strip(), 2)

                    Hour_OptionsList.append(TempHour)
      HourOptions.close()
   return(Hour_OptionsList,Choices_List)


def ScheduleTrimmer1(Hour_OptionsList,Shift,numWorkerGoal,CountUpper,MULTIPLE_SHIFTS,MIX_MAJORS,MIX_AGES):
  NumExtraWorkers = len(Hour_OptionsList[Shift].workerNames)-numWorkerGoal
  if (NumExtraWorkers>0):
      LargestNumberOfShifts=0
      NumberOfUpperClassmen=0
      TempKickList=[]
      for worker in Hour_OptionsList[Shift].workerNames:
          if worker.NumberOfShifts > worker.Hours_Wanted:
              TempKickList.append(worker)##apending all workers scheduled for to many shifts
              LargestNumberOfShifts = max(LargestNumberOfShifts , worker.NumberOfShifts)
          if(worker.Year == "Senior" or worker.Year == "Junior"):
              NumberOfUpperClassmen+=1

      #Ages
      if MIX_AGES:
         if(CountUpper and NumberOfUpperClassmen == 1):##Removes upperclass if only one
           for staff in TempKickList:
              if (staff.Year == "Senior" or staff.Year == "Junior"):
                  TempKickList.remove(staff)

      #Consecutive Shifts
      if MULTIPLE_SHIFTS:
          for staff in TempKickList:
              if NumExtraWorkers>0:
                  if staff in Hour_OptionsList[Shift-1].workerNames or staff in Hour_OptionsList[min(Shift+1,len(Hour_OptionsList)-1)].workerNames:
                      if len(TempKickList) > NumExtraWorkers:
                        #Removes Staff from temp list
                        TempKickList.remove(staff)
      else:
          for staff in TempKickList:
            if NumExtraWorkers>0:
                 if staff in Hour_OptionsList[Shift-1].workerNames or staff in Hour_OptionsList[min(Shift+1,len(Hour_OptionsList)-1)].workerNames:
                    #Removes Staff from shift
                    NumExtraWorkers -=1
                    staff.NumberOfShifts-=1
                    TempKickList.remove(staff)
                    Hour_OptionsList[Shift].workerNames.remove(staff)

      #Mixing Majors
      matches_found = True
      if MIX_MAJORS:
         while (len(TempKickList)>0 and NumExtraWorkers>0 and matches_found):
            MostMatchesOverall = -1
            CurrentLargestFieldWorker = BlankWorker
                        
            for staff in TempKickList:
                MostMatches = -1
                for FieldStudy in staff.Field_Of_Study:##Possible to have more than 1 major
                     MajorMatches = 0
                     for otherstaff in Hour_OptionsList[Shift].workerNames:
                        if FieldStudy in otherstaff.Field_Of_Study:
                            MajorMatches+=1
                     if MajorMatches > MostMatches:
                      MostMatches = MajorMatches    
                if MostMatches >= MostMatchesOverall:
                  MostMatchesOverall = MostMatches
                  CurrentLargestFieldWorker = staff

            if MostMatchesOverall > 1:#probably 1 and not 0
                #Removes Staff from shift
                NumExtraWorkers -=1
                CurrentLargestFieldWorker.NumberOfShifts-=1
                TempKickList.remove(CurrentLargestFieldWorker)
                Hour_OptionsList[Shift].workerNames.remove(CurrentLargestFieldWorker)
            else:
                matches_found = False

      #Largest Differences
      while (len(TempKickList)>0 and NumExtraWorkers>0):
        CurrentLargestFieldWorker = BlankWorker
        biggest_diff = 0
        for staff in TempKickList:
            if (staff.NumberOfShifts - staff.Hours_Wanted) > biggest_diff:
                CurrentLargestFieldWorker = staff
                biggest_diff = staff.NumberOfShifts - staff.Hours_Wanted

        #Removes Staff from shift
        NumExtraWorkers -=1
        CurrentLargestFieldWorker.NumberOfShifts-=1
        TempKickList.remove(CurrentLargestFieldWorker)
        Hour_OptionsList[Shift].workerNames.remove(CurrentLargestFieldWorker)


def CreateOutputFile (Hour_OptionsList,WorkersList):
  OutFileName="Schedule.csv"
  with open (OutFileName, "w", encoding='utf-8') as OutFile:
    Columns = ["Time", "Workers", "Number Of Workers"]
    writer = csv.DictWriter(OutFile, fieldnames=Columns)
    writer.writeheader()
    for Shift in Hour_OptionsList:
        TempNameList=[]
        for name in Shift.workerNames:
            TempNameList.append(name.Name)
        writer.writerow({"Time": Shift.hour, "Workers": TempNameList, "Number Of Workers": len(TempNameList)})
    OutFile.close()
    

def PrintErrorReport(Hour_OptionsList,WorkersList,SHIFT_MAXIMUM_WORKERS,SHIFT_MINIMUM_WORKERS):
    ErrorList=[]
    
    for Shift in Hour_OptionsList:#Calculates/Prints Worker Packing Fraction
      TempNameList=[]
      for name in Shift.workerNames:
        if (name.NumberOfShifts>name.Hours_Wanted or name.NumberOfShifts<name.Hours_Wanted):
          if name not in ErrorList:
            ErrorList.append(name) 
    print("\n"+ "Exceptions for Workers")
    for name in ErrorList:
      print(name.Name + ": " + str(name.NumberOfShifts) + "/" + str(name.Hours_Wanted))
    print("Worker Placement Efficiency = " + str((1-(len(ErrorList)/len(WorkersList)))*100)+"%")

  
    print("\n"+"Exceptions for Shifts")#Calculates/Prints Shift Packing Fraction
    PackingErrors = 0
    for shift in Hour_OptionsList:
      length = len(shift.workerNames)
      if(length> SHIFT_MAXIMUM_WORKERS):
        PackingErrors+=1
        print(shift.hour + ": " + str(length) + "/" + str(SHIFT_MAXIMUM_WORKERS))
      elif(length < SHIFT_MINIMUM_WORKERS):
        PackingErrors+=1
        print(shift.hour + ": " + str(length) + "/" + str(SHIFT_MINIMUM_WORKERS))
    print("Shift Packing Efficiency = " + str((1-(PackingErrors/len(Hour_OptionsList)))*100)+"%")


Main()#Activates the program automatically


                       



