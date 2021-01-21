<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="Lab_4_CSharp.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div style="position:absolute; top:77px; left:196px; width: 1200px; height: 1200px;">
            <asp:TextBox ID="TextBox1" runat="server" type="date"></asp:TextBox>

                 <asp:TextBox ID="TextBox2" runat="server" Text="10.10.2020" type="date">10.10.2020</asp:TextBox>
  

        <asp:Button ID="Button2" runat="server" Text="Отобразить" OnClick="Button2_Click" />
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px" Height="500px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">

             

            <AlternatingRowStyle BackColor="#cbe8ba" />
            <Columns>
                <asp:TemplateField HeaderText="X" ItemStyle-Width="10">                    
                   <ItemTemplate>                       
                       <asp:CheckBox ID="CheckBox1" runat="server" data-Value='<%# Eval("id_Order") %>'  />
                   </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />

<ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
               </asp:TemplateField>               
                <asp:TemplateField HeaderText="Код записи" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_o" runat="server" Text='<%# Eval("id_Order") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>                    

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Код клиента" Visible="false" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_stud" runat="server" Text='<%# Eval("id_Client_FK") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ФИО клиента" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="FIO" runat="server" Text='<%# Eval("FIO") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Код Автобуса" Visible="false" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_dis" runat="server" Text='<%# Eval("id_Bus_FK") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Название автобуса" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="name_dis" runat="server" Text='<%# Eval("Name_car") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Дата" ItemStyle-Width="150" >
                    <ItemTemplate>
                        <asp:Label ID="dateEx" runat="server" Text='<%# Eval("date","{0:dd.MM.yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Стоимость" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="ocenkaEx" runat="server" Text='<%# Eval("cost") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
            </Columns>
              <AlternatingRowStyle BackColor="PaleGoldenrod" />
              <FooterStyle BackColor="Tan" />
              <HeaderStyle BackColor="Tan" Font-Bold="True" />
              <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
              <SortedAscendingCellStyle BackColor="#FAFAE7" />
              <SortedAscendingHeaderStyle BackColor="#DAC09E" />
              <SortedDescendingCellStyle BackColor="#E1DB9C" />
              <SortedDescendingHeaderStyle BackColor="#C2A47B" />
          </asp:GridView>
          <asp:Button ID="Button1" runat="server" BackColor="#99FF66" OnClick="Button1_Click" Text="Удалить" />
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RentBusConnectionString %>" SelectCommand="SELECT [Order].id_Order AS [№ Заказа], Client.FIO AS ФИО, Bus.Name_car AS [Название машины], [Order].date AS Дата, [Order].cost AS Цена FROM Bus INNER JOIN [Order] ON Bus.id_Bus = [Order].id_Bus_FK INNER JOIN Client ON [Order].id_Client_FK = Client.id_Client"></asp:SqlDataSource>

          </div>

</asp:Content>
