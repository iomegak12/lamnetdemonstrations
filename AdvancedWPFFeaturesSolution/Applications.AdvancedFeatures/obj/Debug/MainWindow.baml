   M S B A M L   `   `   `  ����X  TApplications.AdvancedFeatures, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Applications.AdvancedFeaturesApplications.AdvancedFeatures  5   	   .    (Applications.AdvancedFeatures.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Applications.AdvancedFeatures     5   	   K GLibraries.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0models#http://schemas.lamsearch.com/models  5   	   M ILibraries.Commands, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null6commands'http://schemas.lamresearch.com/commands  5   	   R NLibraries.Extensibility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null@extensibility,http://schemas.lamresearch.com/extensibility  5	   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$ SingleBorderWindow=�6Z    � 	Resources 5         Libraries.Models.Customers   	customers  Libraries.Models.Orders 
 orders-  'Libraries.Commands.LoadCustomersCommand  loadCustomers*  $Libraries.Commands.LoadOrdersCommand  
loadOrders2  ,Libraries.Extensibility.CommandInfoConverter  commandInfoConverter��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6     5   
   6     5   
   6(     5   
   6%     5   
   6-   5      .��5      � .+�5   
   �� $
��Load��6   $
��Left=�6    #��[ 5      #��[  5      $��	10,10,0,0q�5      $	��Top=�6$   $��75��6<   �� 5   
   -   5         ��Name$ lstCustomers��5      #��[  6(   -  'Libraries.Extensibility.CommandProvider   Command# [ 6Q    �� DisplayMemberPath$
 Name��5      $	��147��6+   $��10,35,10.2,0q�68   $	��Top=�6N      CommandParameter 5      `� 5       `� 	Converter# [ 6   .1�5      �� 	 �� ElementName$	 lstCustomers��6   
 �� Path$
 SelectedItem�69   �� 5       �� Source# [ 6   5       5"      &   System.Windows.Controls.DataGrid  5#   
      AutoGenerateColumns . $��10,187,10.2,9.8q�6s   ��6.   �� # [  �� IsAsync . 6s   5%      5&      