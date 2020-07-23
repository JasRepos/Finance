<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerManage.aspx.cs" Inherits="CustomerApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript" src="Scripts/ajax/ajax.js"></script>
		<div style="height:100px;"></div>
	<div class="row">
		<div class="col-md-1"></div>
		<div class="col-md-7">
			<h2>Show Customer Details</h2><br />
		</div>



	</div>


	<div class="row">
		<div class="col-md-1"></div>

		<div class="col-md-10">
			<div id="divInput">
				<table class="table  table-bordered" id="tblInput">
					
						<tr >
							<td colspan="5">
								<strong>Please Enter Customer ID</strong> 
							</td>
						</tr>
					
					
						<tr>
							<td>Customer ID</td>
							<td><input type="text" id="txtCustomerId" /> </td>
							<td><input id="btnCustomerDetails" class="btn btn-success" type="button" value="Show Customer Details" /> </td>
							<td><input id="btnDeleteCustomer" class="btn btn-danger" type="button" value="Delete this Customer" /> </td>

						</tr>

					
				</table>
			</div>
		</div>
	</div>

	<div class="row">
		<div class="col-md-1"></div>
		<div class="col-md-10">
			<div>
				<table class="table table-bordered">
						<tr>
							<td colspan="5">
								 <strong>Customer Details</strong>
							</td>
						</tr>
					<tbody>
						<tr>
							<td>Tittle:</td>
							<td>
				<select class="" id="inputGroupSelect01">
					<option selected>Choose...</option>
					<option value="0">Mr</option>
					<option value="1">Ms</option>
					<option value="2">Mrs</option>
					<option value="3">Miss</option>
					<option value="4">Dr</option>

				</select>

							</td>
						</tr>
						<tr>
							<td>First Name:</td>
							<td>
								<input type="text" class="form-control" id="txtFirstName" >
							</td>
						</tr>
						<tr>
							<td>Middle Name:</td>
							<td>
								<input type="text" class="form-control" id="txtMiddleName" >
							</td>
						</tr>
						<tr>
							<td>Last Name:</td>
							<td>
								<input type="text" class="form-control" id="txtLastName" >
							</td>
						</tr>
						<tr>
							<td>Date of Birth:</td>
							<td>
								<input type="text" class="form-control" id="txtDOB" >
							</td>
						</tr>
						<tr>
							<td style="border:none;">

							</td>

							<td >
								<input id="btnUpdateCustomer" class="btn btn-info" type="button" value="Update this Customer" />
							</td>
						</tr>
					</tbody>
				</table>

			</div>
		</div>


	</div>

	<div class="row">
		<div class="col-md-1"></div>
		<div class="col-md-10">
			<div class="row">
				<div class="col-md-8">
					<input id="btnLoadEmployees" class="btn btn-success"
						   type="button" value="Show All Customers" />

				</div>
				<div class="col-md-2">
					<input id="btnClearData" class="btn btn-danger"
						   type="button" value="Close" />

				</div>
			</div><br />
			<div id="divData" class="well hidden">
				<table class="table table-bordered" id="tblData">
					<thead>
						<tr class="success">
							<td>Customer ID</td>
							<td>Tittle</td>
							<td>First Name</td>
							<td>Middle Name</td>
							<td>Last Name</td>
							<td>Date of Birth</td>
						</tr>
					</thead>
					<tbody id="tblBody"></tbody>
				</table>
			</div>
			<div id="divError" class="alert alert-danger collapse">
				<a id="linkClose" href="#" class="close">&times;</a>
				<div id="divErrorText"></div>
			</div>
		</div>

	</div>
</asp:Content>
