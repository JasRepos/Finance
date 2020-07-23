<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

		<div style="height: 100px;"></div>


	<div class="row">
		<div class="col-md-1"></div>
		<div class="col-md-6">
			<div class="card">
				<div class="container">
					<h2>Manage Existing Customers </h2>
					List of Existing Customers and their details<br /> <br />
					<a class="btn btn-info" href="CustomerManage">Customers</a>
					<p> </p>
				</div>
			</div>
		</div>
		<div class="col-md-4">
			<div class="card">
				<div class="container">
					<h2>Register Customer</h2>
					Register a new Customer<br /> <br />
					<a class="btn btn-info" href="CustomerRegister">Register</a>
					<p> </p>

				</div>
			</div>
		</div>
	</div>



</asp:Content>
