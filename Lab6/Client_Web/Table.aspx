<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="Client_Web.TableWithAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px" Height="500px">

             

            <Columns>
                <asp:TemplateField HeaderText="Код обслуживания" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_o" runat="server" Text='<%# Eval("Код обслуживания") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>                    

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Наименование авто" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_stud" runat="server" Text='<%# Eval("Наименование авто") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Наименование работы" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="FIO" runat="server" Text='<%# Eval("Наименование работы") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Стоимость" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_dis" runat="server" Text='<%# Eval("Стоимость") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Стандартное время работы" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="name_dis" runat="server" Text='<%# Eval("Стандартное время работы") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Фактическое время работы" ItemStyle-Width="150" >
                    <ItemTemplate>
                        <asp:Label ID="dateEx" runat="server" Text='<%# Eval("Фактическое время работы") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
        <div style=" width: 992px; height: 1057px;">
       <p>
           
           Наименование авто: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ValidationGroup ="Group1" ID="RequiredFieldValidator3" ControlToValidate="TextBox1" 
                ErrorMessage="Введите наименование авто" Display="dynamic"></asp:RequiredFieldValidator>
        
       </p>
        <p>
            Наименование работы: <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
        </p>
        
            Время работы: 
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ValidationGroup ="Group1" ID="RequiredFieldValidator1" ControlToValidate="TextBox2" 
                ErrorMessage="Введите время работы" Display="dynamic"></asp:RequiredFieldValidator>
        
        <p>
            <asp:Button ValidationGroup ="Group1" ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" />
        </p>

       
       
    </div>
    </form>
</body>
</html>
