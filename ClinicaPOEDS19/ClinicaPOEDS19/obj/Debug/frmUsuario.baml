   M S B A M L   `   `   `  ����I  EClinicaPOEDS19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClinicaPOEDS19ClinicaPOEDS19  5   	       ClinicaPOEDS19.frmUsuario   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   (localclr-namespace:ClinicaPOEDS19  5   	     N� Title$  
frmUsuario��5
   	   $	��450��6   $	��800��6)   .��5      � .+�5      �� .+�5      �� -   5         ��Name$ 
txtUsuario��5      $
��Left=�5      $��	28,10,0,0q�5      $	��Top=�6(   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��5       %  !MaterialDesignFloatingHintTextBox#��[  5      $	��145��6P   G� 5      -   5         G�Name$ txtClave��5      $
��Left=�5      $��	28,10,0,0q�5      $	��Top=�6(   $ Clave��5       ) %MaterialDesignFloatingHintPasswordBox#��[ 5      $	��145��6S   �� 5      -   5         ��Name$ 	cmbEstado��5      $
��Left=�62   $	��145��6M   $ Estado��5      $��	28,32,0,0q�5      $	��Top=�6(   6B   �� 5      $
��0,20q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgusuarios��5         AutoGenerateColumns .     
IsReadOnly . $
��Left=�5        $	��193��5!      $��
28,100,0,0q�6    $	��Top=�64   $	��754��6L      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Codigo��61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6A   �� *Id+  5%      $	 Usuario��61   
 6B   �� *	Usuario+  5&      $	 Estado��61   
 6A   �� *Estado+  5'      $	 Clave��62      
Visibility$ Hidden=�5(   L   
 61   �� *Clave+6L     50      $	 Fecha creacion��61   
 6I   �� *FechaCreacion+53      54      56      �� 5:   
   -   5         ��Name$ 
btnAgregar��5:      $��Agregar��6%   $
��Left=�5;      $��
672,38,0,0q�6,   $	��Top=�6@   $��32��5<      $��94��6   6(   �� 5=   
   -   5        $ btnModificar��5=      $��	Modificar��6'   $
��Left=�6;   $��
672,79,0,0q�5>      $	��Top=�6%   $��32��6=   $��94��6I   5?      �� 5@   
   -   5        $ btnEliminar��5@      $��Eliminar��6&   $
��Left=�5A      $��672,122,0,0q�6,   $	��Top=�6A   $��32��5B      $��94��6   6(   �� 5C   
   -   5        $ 
btnLimpiar��5C      $��Limpiar��6%   $
��Left=�5D      $��672,162,0,0q�6,   $	��Top=�6A   $��32��5E      $��94��6   6(   �� 5F   
   $��GESTION DE USUARIOS��6   $
��Left=�6.   $��	289,3,0,0q�6I   $	��Top=�6\   $	��210��6t   $
��Bold"�6�   $��16(�6�   5G      5H      