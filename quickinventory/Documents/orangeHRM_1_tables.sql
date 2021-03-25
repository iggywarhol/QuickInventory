create table hs_hr_config (
	[key] varchar(100) not null default '',
	value varchar(512) not null default '',
	primary key ([key])
) ;

create table ohrm_employment_status (
	id int not null IDENTITY    ,
	[name] varchar(60) not null,
  primary key  (id)
) ;

create table ohrm_job_category (
	id int not null IDENTITY    ,
	name varchar(60) default null,
  primary key  (id)
) ;

create table hs_hr_jobtit_empstat (
	jobtit_code int not null,
	estat_code int not null,
  primary key  (jobtit_code,estat_code)
) ;

create table hs_hr_country (
  cou_code varchar(3) not null default '',
  name varchar(80) not null default '',
  cou_name varchar(80) not null default '',
  iso3 char(3) default null,
  numcode smallint default null,
  primary key  (cou_code)
) ;

create table hs_hr_currency_type (
  code int not null default '0',
  currency_id varchar(6) not null default '',
  currency_name varchar(70) not null default '',
  primary key  (currency_id)
) ;

create table ohrm_license (
	id int not null IDENTITY    ,
	name varchar(100) not null,
  primary key  (id)
) ;

create table hs_hr_district (
  district_code varchar(13) not null default '',
  district_name varchar(50) default null,
  province_code varchar(13) default null,
  primary key  (district_code)
) ;

create table hs_hr_payperiod (
  payperiod_code varchar(13) not null default '',
  payperiod_name varchar(100) default null,
  primary key  (payperiod_code)
) ;

create table hs_hr_emp_basicsalary (
  id INT IDENTITY    ,
  emp_number int not null default 0,
  sal_grd_code int default null,
  currency_id varchar(6) not null default '',
  ebsal_basic_salary VARCHAR(100)  DEFAULT null,
  payperiod_code varchar(13) default null,
  salary_component varchar(100),
  comments varchar(255),
  primary key  (id)
) ;

create table hs_hr_emp_contract_extend (
  emp_number int not null default 0,
  econ_extend_id decimal(10,0) not null default '0',
  econ_extend_start_date datetime default null,
  econ_extend_end_date datetime default null,
  primary key  (emp_number,econ_extend_id)
) ;


create table hs_hr_emp_language (
  emp_number int not null default 0,
  lang_id int not null,
  fluency smallint default '0',
  competency smallint default '0',
  comments varchar(100),
  primary key  (emp_number,lang_id,fluency)
) ;

create table hs_hr_emp_us_tax (
  emp_number int not null default 0,
  tax_federal_status varchar(13) default null,
  tax_federal_exceptions int default 0,
  tax_state varchar(13) default null,
  tax_state_status varchar(13) default null,
  tax_state_exceptions int default 0,
  tax_unemp_state varchar(13) default null,
  tax_work_state varchar(13) default null,
  primary key  (emp_number)
) ;

create table hs_hr_emp_attachment (
  emp_number int not null default 0,
  eattach_id int not null default '0',
  eattach_desc varchar(200) default null,
  eattach_filename varchar(100) default null,
  eattach_size int default 0,
  eattach_attachment image,
  eattach_type varchar(200) default null,
  screen varchar(100) default '',
  attached_by int default null,
  attached_by_name varchar(200),
  attached_time timestamp,
  primary key  (emp_number,eattach_id)
  /*key screen ([screen])*/
) ;


create table hs_hr_emp_children (
  emp_number int not null default 0,
  ec_seqno decimal(2,0) not null default '0',
  ec_name varchar(100) default '',
  ec_date_of_birth date null default null,
  primary key  (emp_number,ec_seqno)
) ;

create table hs_hr_emp_dependents (
  emp_number int not null default 0,
  ed_seqno decimal(2,0) not null default '0',
  ed_name varchar(100) default '',

  ed_relationship_type varchar(100) default 'child'
  CHECK(ed_relationship_type IN ('child','other')),

  ed_relationship varchar(100) default '',
  ed_date_of_birth date null default null,
  primary key  (emp_number,ed_seqno)
) ;

create table hs_hr_emp_emergency_contacts (
  emp_number int not null default 0,
  eec_seqno decimal(2,0) not null default '0',
  eec_name varchar(100) default '',
  eec_relationship varchar(100) default '',
  eec_home_no varchar(100) default '',
  eec_mobile_no varchar(100) default '',
  eec_office_no varchar(100) default '',
  primary key  (emp_number,eec_seqno)
) ;


create table hs_hr_emp_history_of_ealier_pos (
  emp_number int not null default 0,
  emp_seqno decimal(2,0) not null default '0',
  ehoep_job_title varchar(100) default '',
  ehoep_years varchar(100) default '',
  primary key  (emp_number,emp_seqno)
) ;


create table ohrm_emp_license (
  emp_number int not null,
  license_id int not null,
  license_no varchar(50) default null,
  license_issued_date date null default null,
  license_expiry_date date null default null,
  primary key (emp_number,license_id)
) ;


create table hs_hr_emp_member_detail (
  id int IDENTITY    ,
  emp_number int not null default 0,
  membship_code int not null default 0,
  ememb_subscript_ownership varchar(20) default null,
  ememb_subscript_amount decimal(15,2) default null,
  ememb_subs_currency varchar(20) default null,
  ememb_commence_date date default null,
  ememb_renewal_date date default null,
  primary key  (id)
) ;


create table hs_hr_emp_passport (
  emp_number int not null default 0,
  ep_seqno decimal(2,0) not null default '0',
  ep_passport_num varchar(100) not null default '',
  ep_passportissueddate datetime default null,
  ep_passportexpiredate datetime default null,
  ep_comments varchar(255) default null,
  ep_passport_type_flg smallint default null,
  ep_i9_status varchar(100) default '',
  ep_i9_review_date date null default null,
  cou_code varchar(6) default null,
  primary key  (emp_number,ep_seqno)
) ;

create table hs_hr_emp_directdebit (
  id INT IDENTITY    ,
  salary_id INT NOT NULL,
  dd_routing_num int not null,
  dd_account varchar(100) not null default '',
  dd_amount decimal(11,2) not null,
  dd_account_type varchar(20) not null default '',
  dd_transaction_type varchar(20) not null default '',
  primary key  (id)
) ;

/*

  dd_account_type varchar(20) not null default '' comment 'CHECKING SAVINGS',
  dd_transaction_type varchar(20) not null default '' comment 'BLANK, PERC, FLAT, FLATMINUS',

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = 'This is the description of my column',
    @level0type = N'Schema', @level0name = 'dbo',
    @level1type = N'Table', @level1name = 'MyTable', 
    @level2type = N'Column', @level2name = 'MyColumn'
 */


create table hs_hr_emp_skill (
  emp_number int not null default 0,
  skill_id int not null,
  years_of_exp decimal(2,0) default null,
  comments varchar(100) not null default ''
) ;

create table hs_hr_emp_picture (
  emp_number int not null default 0,
  epic_picture image,
  epic_filename varchar(100) default null,
  epic_type varchar(50) default null,
  epic_file_size varchar(20) default null,
  epic_file_width varchar(20) default null,
  epic_file_height varchar(20) default null,
  primary key  (emp_number)
) ;


create table ohrm_emp_education (
  id int not null IDENTITY    ,
  emp_number int not null,
  education_id int not null,
  institute varchar(100) default null,
  major varchar(100) default null,
  year decimal(4,0) default null,
  score varchar(25) default null,
  start_date date default null,
  end_date date default null,
  primary key  (id)
) ;


create table hs_hr_emp_reportto (
  erep_sup_emp_number int not null default 0,
  erep_sub_emp_number int not null default 0,
  erep_reporting_mode int not null default 0,
  primary key  (erep_sup_emp_number,erep_sub_emp_number, erep_reporting_mode)
) ;

create table ohrm_emp_reporting_method (
  reporting_method_id int not null IDENTITY    ,
  reporting_method_name varchar(100) not null,
  primary key  (reporting_method_id)
) ;

create table hs_hr_emp_work_experience (
  emp_number int not null default 0,
  eexp_seqno decimal(10,0) not null default '0',
  eexp_employer varchar(100) default null,
  eexp_jobtit varchar(120) default null,
  eexp_from_date datetime default null,
  eexp_to_date datetime default null,
  eexp_comments varchar(200) default null,
  eexp_internal int default null,
  primary key  (emp_number,eexp_seqno)
) ;


create table hs_hr_employee (
  emp_number int not null IDENTITY    ,
  employee_id varchar(50) default null,
  emp_lastname varchar(100) default '' not null,
  emp_firstname varchar(100) default '' not null,
  emp_middle_name varchar(100) default '' not null,
  emp_nick_name varchar(100) default '',
  emp_smoker smallint default '0',
  ethnic_race_code varchar(13) default null,
  emp_birthday date null default null,
  nation_code int default null,
  emp_gender smallint default null,
  emp_marital_status varchar(20) default null,
  emp_ssn_num varchar(100) DEFAULT '',
  emp_sin_num varchar(100) default '',
  emp_other_id varchar(100) default '',
  emp_dri_lice_num varchar(100) default '',
  emp_dri_lice_exp_date date null default null,
  emp_military_service varchar(100) default '',
  emp_status int default null,
  job_title_code int default null,
  eeo_cat_code int default null,
  work_station int default null,
  emp_street1 varchar(100) default '',
  emp_street2 varchar(100) default '',
  city_code varchar(100) default '',
  coun_code varchar(100) default '',
  provin_code varchar(100) default '',
  emp_zipcode varchar(20) default null,
  emp_hm_telephone varchar(50) default null,
  emp_mobile varchar(50) default null,
  emp_work_telephone varchar(50) default null,
  emp_work_email varchar(50) default null,
  sal_grd_code varchar(13) default null,
  joined_date date null default null,
  emp_oth_email varchar(50) default null,
  termination_id int default null,
  custom1 varchar(250) default null,
  custom2 varchar(250) default null,
  custom3 varchar(250) default null,
  custom4 varchar(250) default null,
  custom5 varchar(250) default null,
  custom6 varchar(250) default null,
  custom7 varchar(250) default null,
  custom8 varchar(250) default null,
  custom9 varchar(250) default null,
  custom10 varchar(250) default null,
  purged_at TIMESTAMP NULL,

  primary key  (emp_number)
) ;

create table ohrm_language (
  id int not null IDENTITY    ,
  name varchar(120) default null,
  primary key  (id)
) ;


create table ohrm_location (
  id int not null IDENTITY    ,
  name varchar(110) not null,
  country_code varchar(3) not null,
  province varchar(60) default null,
  city varchar(60) default null,
  address varchar(255) default null,
  zip_code varchar(35) default null,
  phone varchar(35) default null,
  fax varchar(35) default null,
  notes varchar(255) default null,
  primary key  (id)
) ;

CREATE  TABLE ohrm_operational_country (
  id INT  NOT NULL IDENTITY ,
  country_code varchar(3) DEFAULT NULL,
  PRIMARY KEY (id)
) 

create table hs_hr_module (
  mod_id varchar(36) not null default '',
  name varchar(45) default null,
  owner varchar(45) default null,
  owner_email varchar(100) default null,
  version varchar(36) default null,
  description text,
  primary key  (mod_id)
) ;

create table hs_hr_province (
  id int not null IDENTITY    ,
  province_name varchar(40) not null default '',
  province_code char(2) not null default '',
  cou_code char(2) not null default 'us',
  primary key  (id)
) ;

create table ohrm_education (
	id int not null IDENTITY    ,
	name varchar(100) not null,
	primary key (id)
) ;

create table ohrm_skill (
  id int not null IDENTITY    ,
  name varchar(120) default null,
  [description] text default null,
  primary key  (id)
) ;

create table ohrm_pay_grade_currency (
  pay_grade_id int not null ,
  currency_id varchar(6) not null default '',
  min_salary float(53)  DEFAULT NULL,
  max_salary float(53) DEFAULT NULL,
  primary key  (pay_grade_id,currency_id)
) ;

create table ohrm_pay_grade (
  id int not null IDENTITY    ,
  name varchar(60) default null unique,
  primary key  (id)
) ;

CREATE TABLE ohrm_holiday (
  id INT IDENTITY(-32000,1),
  description TEXT DEFAULT NULL,
  date DATE DEFAULT NULL,
  recurring TINYINT DEFAULT 0,
  length INT DEFAULT NULL,
  operational_country_id INT DEFAULT NULL,
  PRIMARY KEY (id)
) ;

CREATE  TABLE ohrm_work_week (
  id INT NOT NULL IDENTITY ,
  operational_country_id INT NULL DEFAULT NULL ,
  mon TINYINT  NOT NULL DEFAULT 0 ,
  tue TINYINT  NOT NULL DEFAULT 0 ,
  wed TINYINT  NOT NULL DEFAULT 0 ,
  thu TINYINT  NOT NULL DEFAULT 0 ,
  fri TINYINT  NOT NULL DEFAULT 0 ,
  sat TINYINT  NOT NULL DEFAULT 0 ,
  sun TINYINT  NOT NULL DEFAULT 0 ,
  PRIMARY KEY (id)
) ;

create table hs_hr_mailnotifications (
	user_id int not null,
	notification_type_id int not null ,
	status int not null,
    email varchar(100) default null,
	INDEX user_id (user_id),
	INDEX notification_type_id (notification_type_id)
) ;

create table ohrm_customer (
  customer_id int not null IDENTITY,
  name varchar(100) not null,
  description varchar(255) default null,
  is_deleted tinyint default 0,
  primary key  (customer_id)
) ;

create table ohrm_project (
  project_id int not null IDENTITY,
  customer_id int not null,
  name varchar(100) default null,
  description varchar(256) default null,
  is_deleted tinyint default 0,
  primary key  (project_id,customer_id),
  INDEX customer_id (customer_id)
) ;

create table ohrm_project_activity (
  activity_id int not null IDENTITY,
  project_id int not null,
  name varchar(110) default null,
  is_deleted tinyint default 0,
  primary key  (activity_id),
  INDEX project_id (project_id)
) ;

create table ohrm_project_admin (
  project_id int not null,
  emp_number int not null,
  primary key  (project_id,emp_number),
  INDEX emp_number (emp_number)
) ;

create table hs_hr_unique_id (
  id int not null IDENTITY,
  last_id int  not null,
  table_name varchar(50) not null,
  field_name varchar(50) not null,
  primary key(id),
  INDEX table_field unique (table_name, field_name)
) ;

create table ohrm_work_shift (
  id int not null IDENTITY,
  name varchar(250) not null,
  hours_per_day decimal(4,2) not null,
  start_time time not null,
  end_time time not null,
  primary key  (id)
) ;

create table ohrm_employee_work_shift (
  work_shift_id int not null IDENTITY,
  emp_number int not null,
  primary key  (work_shift_id,emp_number),
  INDEX emp_number (emp_number)
) ;

create table hs_hr_custom_fields (
  field_num int not null,
  name varchar(250) not null,
  type int not null,
  screen varchar(100),
  extra_data varchar(250) default null,
  primary key  (field_num),
  INDEX emp_number (field_num),
  INDEX screen (screen)
) ;

create table hs_hr_pay_period (
	id int not null ,
	start_date date not null ,
	end_date date not null ,
	close_date date not null ,
	check_date date not null ,
	timesheet_aproval_due_date date not null ,
	primary key (id)
) ;

create table hs_hr_custom_export (
  export_id int not null,
  name varchar(250) not null,
  fields text default null,
  headings text default null,
  primary key  (export_id),
  INDEX emp_number (export_id)
) ;

create table hs_hr_custom_import (
  import_id int not null,
  name varchar(250) not null,
  fields text default null,
  has_heading tinyint default 0,
  primary key  (import_id),
  INDEX emp_number (import_id)
) ;

create table hs_hr_emp_locations (
  emp_number int not null,
  location_id int not null,
  primary key  (emp_number, location_id)
) ;

create table ohrm_timesheet(
  timesheet_id bigint not null IDENTITY,
  state varchar(255) not null,
  start_date date not null,
  end_date date not null,
  employee_id bigint not null,
  primary key  (timesheet_id)
) ;

create table ohrm_timesheet_item(
  timesheet_item_id bigint not null IDENTITY,
  timesheet_id bigint not null,
  date date not null,
  duration bigint default null,
  comment text default null,
  project_id bigint not null,
  employee_id bigint not null,
  activity_id bigint not null,
  primary key  (timesheet_item_id),
  INDEX timesheet_id (timesheet_id),
  INDEX activity_id (activity_id)
) ;

create table ohrm_timesheet_action_log(
  timesheet_action_log_id bigint not null IDENTITY,
  comment varchar(255) default null,
  action varchar(255),
  date_time date not null,
  performed_by int not null,
  timesheet_id bigint not null,
  primary key  (timesheet_action_log_id),
  INDEX timesheet_id (timesheet_id),
  INDEX performed_by(performed_by)
) ;

create table ohrm_workflow_state_machine(
  id bigint not null IDENTITY,
  workflow varchar(255) not null,
  state varchar(255) not null,
  role varchar(255) not null,
  action varchar(255) not null,
  resulting_state varchar(255) not null,
  roles_to_notify text,
  priority int not null default 0, /* COMMENT 'lowest priority 0',*/
  primary key (id)
) ;

create table ohrm_attendance_record(
  id bigint not null IDENTITY,
  employee_id bigint not null,
  punch_in_utc_time datetime ,
  punch_in_note varchar(255),
  punch_in_time_offset varchar(255),
  punch_in_user_time datetime,
  punch_out_utc_time datetime,
  punch_out_note varchar(255),
  punch_out_time_offset varchar(255),
  punch_out_user_time datetime,
  state varchar(255) not null,
  primary key (id),
  INDEX emp_id_state (employee_id,state),
  INDEX emp_id_time (employee_id,punch_in_utc_time,punch_out_utc_time)
) ;

create table ohrm_report_group (
  report_group_id bigint not null,
  name varchar(255) not null,
  core_sql text not null,
  primary key (report_group_id)
) ;

create table ohrm_report (
  report_id bigint not null IDENTITY,
  name varchar(255) not null,
  report_group_id bigint not null,
  use_filter_field bit not null,
  type varchar(255) default null,
  primary key (report_id),
  INDEX report_group_id (report_group_id)
) ;

create table ohrm_filter_field (
  filter_field_id bigint not null,
  report_group_id bigint not null,
  name varchar(255) not null,
  where_clause_part text not null,
  filter_field_widget varchar(255),
  condition_no int not null,
  required varchar(10) default null,
  primary key (filter_field_id),
  INDEX report_group_id (report_group_id)
) ;

create table ohrm_selected_filter_field (
  report_id bigint not null,
  filter_field_id bigint not null,
  filter_field_order bigint not null,
  value1 varchar(255) default null,
  value2 varchar(255) default null,
  where_condition varchar(255) default null,
  type varchar(255) not null,
  primary key (report_id,filter_field_id),
  INDEX report_id (report_id),
  INDEX filter_field_id (filter_field_id)
) ;

create table ohrm_display_field (
  display_field_id bigint not null IDENTITY,
  report_group_id bigint not null,
  name varchar(255) not null,
  label varchar(255) not null,
  field_alias varchar(255),
  is_sortable varchar(10) not null,
  sort_order varchar(255),
  sort_field varchar(255),
  element_type varchar(255) not null,
  element_property varchar(1000) not null,
  width varchar(255) not null,
  is_exportable varchar(10),
  text_alignment_style varchar(20),
  is_value_list bit not null default(0),
  display_field_group_id int,
  default_value varchar(255) default null,
  is_encrypted bit not null default (0),
  is_meta bit not null default (0),
  primary key (display_field_id),
  INDEX report_group_id (report_group_id)
) ;

create table ohrm_composite_display_field (
  composite_display_field_id bigint not null IDENTITY,
  report_group_id bigint not null,
  name varchar(1000) not null,
  label varchar(255) not null,
  field_alias varchar(255),
  is_sortable varchar(10) not null,
  sort_order varchar(255),
  sort_field varchar(255),
  element_type varchar(255) not null,
  element_property varchar(1000) not null,
  width varchar(255) not null,
  is_exportable varchar(10),
  text_alignment_style varchar(20),
  is_value_list bit not null default (0),
  display_field_group_id int,
  default_value varchar(255) default null,
  is_encrypted bit not null default (0),
  is_meta bit not null default (0),
  primary key (composite_display_field_id),
  INDEX report_group_id (report_group_id)
) ;

create table ohrm_group_field (
  group_field_id bigint not null,
  name varchar(255) not null,
  group_by_clause text not null,
  group_field_widget varchar(255),
  primary key (group_field_id)
) ;

create table ohrm_available_group_field (
  report_group_id bigint not null,
  group_field_id bigint not null,
  primary key (report_group_id,group_field_id),
  INDEX report_group_id (report_group_id),
  INDEX group_field_id (group_field_id)
) ;

create table ohrm_selected_display_field (
  id bigint not null IDENTITY,
  display_field_id bigint not null,
  report_id bigint not null,
  primary key (id,display_field_id,report_id),
  INDEX display_field_id (display_field_id),
  INDEX report_id (report_id)
) ;

create table ohrm_selected_composite_display_field (
  id bigint not null,
  composite_display_field_id bigint not null,
  report_id bigint not null,
  primary key (id,composite_display_field_id,report_id),
  INDEX composite_display_field_id (composite_display_field_id),
  INDEX report_id (report_id)
) ;

create table ohrm_summary_display_field (
  summary_display_field_id bigint not null,
 [function] varchar(1000) not null,
  label varchar(255) not null,
  field_alias varchar(255),
  is_sortable varchar(10) not null,
  sort_order varchar(255),
  sort_field varchar(255),
  element_type varchar(255) not null,
  element_property varchar(1000) not null,
  width varchar(255) not null,
  is_exportable varchar(10),
  text_alignment_style varchar(20),
  is_value_list bit not null default (0),
  display_field_group_id int,
  default_value varchar(255) default null,
  primary key (summary_display_field_id)
) ;

create table ohrm_selected_group_field (
  group_field_id bigint not null,
  summary_display_field_id bigint not null,
  report_id bigint not null,
  primary key (group_field_id,summary_display_field_id,report_id),
  INDEX group_field_id (group_field_id),
  INDEX summary_display_field_id (summary_display_field_id),
  INDEX report_id (report_id)
) ;

create table ohrm_display_field_group (
  id int not null IDENTITY,
  report_group_id bigint not null,
  name varchar(255) not null,
  is_list bit not null default (0),
  primary key (id)
) ;

create table ohrm_selected_display_field_group (
  id int  not null IDENTITY,
  report_id bigint not null,
  display_field_group_id int  not null,
  primary key (id)
) ;

create table ohrm_job_vacancy(
	id int not null IDENTITY,
	job_title_code int not null,
        hiring_manager_id int default null,
	name varchar(100) not null,
	description text default null,
	no_of_positions int default null,
    status int not null,
    published_in_feed bit not null default (0),
    defined_time datetime not null,
    updated_time datetime not null,
	primary key (id)
);

create table ohrm_job_candidate(
	id int not null IDENTITY,
	first_name varchar(30) not null,
	middle_name varchar(30) default null,
    last_name varchar(30) not null,
	email varchar(100) not null,
	contact_number varchar(30) default null,
	status int not null,
	comment text default null,
	mode_of_application int not null,
	date_of_application date not null,
    cv_file_id int default null,
    cv_text_version text default null,
    keywords varchar(255) default null,
    added_person int default null,
    consent_to_keep_data bit not null default (0),
	primary key (id)
);

create table ohrm_job_candidate_vacancy(
        id int unique IDENTITY,
	candidate_id int not null,
        vacancy_id int not null,
	status varchar(100) not null,
        applied_date date not null,
	primary key (candidate_id, vacancy_id)
);

create table ohrm_job_candidate_attachment(
	id int not null IDENTITY,
	candidate_id int not null,
	file_name varchar(200) not null,
        file_type varchar(200) default null,
	file_size int not null,
	file_content text,
        attachment_type int default null,
	primary key (id)
);

create table ohrm_job_vacancy_attachment(
	id int not null IDENTITY,
	vacancy_id int not null,
	file_name varchar(200) not null,
        file_type varchar(200) default null,
	file_size int not null,
	file_content image,
        attachment_type int default null,
	comment varchar(255) default null,
	primary key (id)
);

create table ohrm_job_interview_attachment(
	id int not null IDENTITY,
	interview_id int not null,
	file_name varchar(200) not null,
        file_type varchar(200) default null,
	file_size int not null,
	file_content image,
        attachment_type int default null,
	comment varchar(255) default null,
	primary key (id)
);

create table ohrm_job_candidate_history(
	id int not null IDENTITY,
	candidate_id int not null,
	vacancy_id int default null,
	candidate_vacancy_name varchar(255) default null,
	interview_id int default null,
	action int not null,
	performed_by int default null,
        performed_date datetime not null,
	note text default null,
	interviewers varchar(255) default null,
	primary key (id)
);

create table ohrm_job_interview(
	id int not null IDENTITY,
	candidate_vacancy_id int default null,
        candidate_id int default null,
        interview_name varchar(100) not null,
	interview_date date default null,
        interview_time time default null,
	note text default null,
	primary key (id)
);

create table ohrm_job_interview_interviewer(
	interview_id int not null,
	interviewer_id int not null,
	primary key (interview_id, interviewer_id)
);

create table ohrm_subunit (
  id int not null IDENTITY,
  name varchar(100) not null unique,
  unit_id varchar(100) default null,
  description varchar(400),
  lft smallint  default null,
  rgt smallint  default null,
  level smallint  default null,
  primary key (id)
) ;

create table ohrm_organization_gen_info (
  id int not null IDENTITY,
  name varchar(100) not null,
  tax_id varchar(30) default null,
  registration_number varchar(30) default null,
  phone varchar(30) default null,
  fax varchar(30) default null,
  email varchar(30) default null,
  country varchar(30) default null,
  province varchar(30) default null,
  city varchar(30) default null,
  zip_code varchar(30) default null,
  street1 varchar(100) default null,
  street2 varchar(100) default null,
  note varchar(255) default null,
  primary key (id)
) ;

create table ohrm_job_title (
  id int not null IDENTITY,
  job_title varchar(100) not null,
  job_description varchar(400) default null,
  note varchar(400) default null,
  is_deleted tinyint default 0,
  primary key (id)
) ;

create table ohrm_job_specification_attachment(
	id int not null IDENTITY,
	job_title_id int not null,
	file_name varchar(200) not null,
        file_type varchar(200) default null,
	file_size int not null,
	file_content image,
	primary key (id)
);

create table ohrm_emp_termination(
	id int not null IDENTITY,
	emp_number int default null,
        reason_id int default null,
	termination_date date not null,
        note varchar(255) default null,
	primary key (id)
);

create table ohrm_emp_termination_reason(
	id int not null IDENTITY,
    name varchar(100) default null,
	primary key (id)
);

create table ohrm_user(
        id int not null IDENTITY,
        user_role_id int not null,
        emp_number int DEFAULT NULL,
        user_name varchar(40) unique,
        user_password varchar(255) DEFAULT NULL,
        deleted tinyint NOT NULL DEFAULT '0',
        status tinyint NOT NULL DEFAULT '1',
        date_entered datetime null default null,
        date_modified datetime null default null,
        modified_user_id int default null,
        created_by int default null,
        INDEX user_role_id (user_role_id),
        INDEX emp_number (emp_number),
        INDEX modified_user_id(modified_user_id),
        INDEX created_by(created_by),
	primary key (id)
);

create table ohrm_user_role(
	id int not null IDENTITY,
	name varchar(255) not null,
	display_name varchar(255) not null,
	is_assignable tinyint default 0,
        is_predefined tinyint default 0,
        INDEX user_role_name unique(name),
	primary key (id)
);

create table ohrm_user_selection_rule(
	id int not null IDENTITY,
	name varchar(255) not null,
        description varchar(255) ,
	implementation_class varchar(255) not null,
        rule_xml_data text,
	primary key (id)
);

create table ohrm_role_user_selection_rule(
	user_role_id int not null,
        selection_rule_id int not null,
        configurable_params text,
	primary key (user_role_id,selection_rule_id)
);

create table ohrm_membership (
  id int not null IDENTITY,
  name varchar(100) not null,
  primary key  (id)
) ;

create table ohrm_nationality (
  id int not null IDENTITY,
  name varchar(100) not null,
  primary key  (id)
) ;

create table ohrm_email_notification (
  id int not null IDENTITY,
  name varchar(100) not null,
  is_enable int not null,
  primary key  (id)
) ;

create table ohrm_email_subscriber (
  id int not null IDENTITY,
  notification_id int not null,
  name varchar(100) not null,
  email varchar(100) not null,
  primary key  (id)
) ;

create table ohrm_email (
  id int not null IDENTITY,
  [name] varchar(100) not null unique,
  primary key  (id),
   INDEX  ohrm_email_name unique([name])
) ;

create table ohrm_email_template (
  id int not null IDENTITY,
  email_id int not null,
  locale varchar(20),
  performer_role varchar(50) default null,
  recipient_role varchar(50) default null,
  subject varchar(255),
  body text,
  primary key  (id)
) ;

create table ohrm_email_processor (
  id int not null IDENTITY,
  email_id int not null,
  class_name varchar(100),
  primary key  (id)
) ;

create table ohrm_module (
  id int not null IDENTITY,
  name varchar(120) default null,
  status tinyint default 1,
  primary key  (id)
) ;

create table ohrm_screen (
  id int not null IDENTITY,
   name varchar(100) not null,
   module_id int not null,
   action_url varchar(255) not null,
   primary key (id)
) ;

create table ohrm_user_role_screen (
  id int not null IDENTITY,
  user_role_id int not null,
  screen_id int not null,
  can_read tinyint not null default 0,
  can_create tinyint not null default 0,
  can_update tinyint not null default 0,
  can_delete tinyint not null default 0,
  primary key (id)
) ;

create table ohrm_menu_item (
   id int not null IDENTITY,
   menu_title varchar(255) not null,
   screen_id int default null,
   parent_id int default null,
   level tinyint not null,
   order_hint int not null,
   url_extras varchar(255) default null,
   status tinyint not null default 1,
   primary key (id)
) ;

create table ohrm_upgrade_history (
  id int not null IDENTITY,
  start_version varchar(30) DEFAULT NULL,
  end_version varchar(30) DEFAULT NULL,
  start_increment int NOT NULL,
  end_increment int NOT NULL,
  upgraded_date datetime DEFAULT NULL,
  PRIMARY KEY (id)
) ;


create table ohrm_email_configuration (
  id int not null IDENTITY,
  mail_type varchar(50) DEFAULT NULL,
  sent_as varchar(250) NOT NULL,
  smtp_host varchar(250) DEFAULT NULL,
  smtp_port int DEFAULT NULL,
  smtp_username varchar(250) DEFAULT NULL,
  smtp_password varchar(250) DEFAULT NULL,
  smtp_auth_type varchar(50) DEFAULT NULL,
  smtp_security_type varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
) ;


CREATE TABLE ohrm_data_group (
    id int IDENTITY,
    name VARCHAR(255) NOT NULL UNIQUE,
    description VARCHAR(255),
    can_read TINYINT, can_create TINYINT,
    can_update TINYINT,
    can_delete TINYINT,
    PRIMARY KEY(id)
) ;

CREATE TABLE ohrm_user_role_data_group (
    id int IDENTITY,
    user_role_id int,
    data_group_id int,
    can_read TINYINT,
    can_create TINYINT,
    can_update TINYINT,
    can_delete TINYINT,
    self TINYINT,
    PRIMARY KEY(id)
) ;

CREATE TABLE ohrm_leave_type (
  id int  not null IDENTITY,
  name varchar(50) not null,
  deleted tinyint not null default 0,
  exclude_in_reports_if_no_entitlement tinyint not null default 0,
  operational_country_id int  default null,
  primary key  (id)
) ;

CREATE TABLE ohrm_leave_entitlement_type(
  id int  not null IDENTITY,
  name varchar(50) not null,
  is_editable  tinyint not null default 0,
  PRIMARY KEY(id)
);

CREATE TABLE ohrm_leave_entitlement (
  id int  not null IDENTITY,
  emp_number int not null,
  no_of_days decimal(19,15) not null,
  days_used decimal(8,4) not null default 0,
  leave_type_id int not null,
  from_date datetime not null,
  to_date datetime,
  credited_date datetime,
  note varchar(255) default null,
  entitlement_type int not null,
  deleted tinyint not null default 0,
  created_by_id int,
  created_by_name varchar(255),
  PRIMARY KEY(id)
) ;

CREATE TABLE ohrm_leave_adjustment (
  id int not null IDENTITY,
  emp_number int not null,
  no_of_days decimal(19,15) not null,
  leave_type_id int  not null,
  from_date datetime,
  to_date datetime,
  credited_date datetime,
  note varchar(255) default null,
  adjustment_type int  not null default 0,
  deleted tinyint not null default 0,
  created_by_id int,
  created_by_name varchar(255),
  PRIMARY KEY(id)
) ;

-- Do we need the field duplication here (leave_request and leave)?
CREATE TABLE ohrm_leave_request (
  id int NOT NULL IDENTITY,
  leave_type_id int NOT NULL,
  date_applied date NOT NULL,
  emp_number int NOT NULL,
  comments varchar(256) default NULL,
  PRIMARY KEY  (id)
) ;

CREATE TABLE ohrm_leave (
  id int NOT NULL  IDENTITY,
  date date default NULL,
  length_hours decimal(6,2)  default NULL,
  length_days decimal(6,4)  default NULL,
  status smallint default NULL,
  comments varchar(256) default NULL,
  leave_request_id int NOT NULL,
  leave_type_id int NOT NULL,
  emp_number int NOT NULL,
  start_time time default NULL,
  end_time time default NULL,
  duration_type tinyint NOT NULL default 0,
  PRIMARY KEY  (id),
  INDEX leave_request_type_emp(leave_request_id,leave_type_id,emp_number),
  INDEX request_status (leave_request_id,status)
) ;

CREATE TABLE ohrm_leave_comment (
  id int NOT NULL  IDENTITY,
  leave_id int NOT NULL,
  created datetime default NULL,
  created_by_name varchar(255) NOT NULL,
  created_by_id int,
  created_by_emp_number int default NULL,
  comments varchar(255) default NULL,
  PRIMARY KEY  (id)
) ;

CREATE TABLE ohrm_leave_request_comment (
  id int NOT NULL  IDENTITY,
  leave_request_id int  NOT NULL,
  created datetime default NULL,
  created_by_name varchar(255) NOT NULL,
  created_by_id int,
  created_by_emp_number int default NULL,
  comments varchar(255) default NULL,
  PRIMARY KEY  (id)
) ;

create TABLE ohrm_leave_leave_entitlement (
    id int NOT NULL   IDENTITY,
    leave_id int NOT NULL,
    entitlement_id int  NOT NULL,
    length_days decimal(6,4) default NULL,
    PRIMARY KEY  (id)
) ;

create TABLE ohrm_leave_entitlement_adjustment (
    id int NOT NULL   IDENTITY,
    adjustment_id int NOT NULL,
    entitlement_id int NOT NULL,
    length_days decimal(4,2) default NULL,
    PRIMARY KEY  (id)
) ;

CREATE TABLE ohrm_leave_period_history (
  id int NOT NULL IDENTITY,
  leave_period_start_month int NOT NULL,
  leave_period_start_day int NOT NULL,
  created_at date NOT NULL,
  PRIMARY KEY (id)
) ;

CREATE TABLE ohrm_leave_status (
  id int NOT NULL IDENTITY,
  status smallint NOT NULL,
  name varchar(100) NOT NULL,
  PRIMARY KEY (id)
) ;

create table ohrm_advanced_report (
  id int not null,
  name varchar(100) not null,
  definition text not null,
  primary key (id)
) ;

CREATE TABLE ohrm_employee_subscription (
  id int not null IDENTITY,
  employee_id int not null,
  status smallint NOT NULL,
  created_at date NOT NULL,
  PRIMARY KEY(id)
) ;

create table ohrm_home_page (
    id int not null IDENTITY,
    user_role_id int not null,
    action varchar(255),
    enable_class varchar(100) default null,
    priority int not null default 0 /* COMMENT 'lowest priority 0',*/
    primary key (id)
) ;

create table ohrm_module_default_page (
    id int not null IDENTITY,
    module_id int not null,
    user_role_id int not null,
    action varchar(255),
    enable_class varchar(100) default null,
    priority int not null default 0 /*COMMENT 'lowest priority 0',*/
    primary key (id)
) ;

CREATE TABLE ohrm_data_group_screen (
    id int IDENTITY,
    data_group_id int,
    screen_id int,
    permission int,
    PRIMARY KEY(id)
) ;

CREATE TABLE ohrm_plugin (
    id int  IDENTITY,
    [name] varchar(100) not null,
    [version] varchar(32),
    INDEX ohrm_plugin_name_idx([name]),
    primary key(id)
);

alter table ohrm_home_page
    add foreign key (user_role_id) references ohrm_user_role(id) on delete cascade;

alter table ohrm_module_default_page
    add foreign key (user_role_id) references ohrm_user_role(id) on delete cascade,
    foreign key (module_id) references ohrm_module(id) on delete cascade;

alter table ohrm_leave_type
    add foreign key (operational_country_id)
        references ohrm_operational_country(id) on delete set null;

alter table ohrm_leave_entitlement
    add foreign key (leave_type_id)
        references ohrm_leave_type(id) on delete cascade;

alter table ohrm_leave_entitlement
    add foreign key (emp_number)
        references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_leave_entitlement
    add foreign key (entitlement_type)
        references ohrm_leave_entitlement_type(id) on delete cascade;

alter table ohrm_leave_entitlement
    add foreign key (created_by_id)
        references ohrm_user(id) on delete set null;

alter table ohrm_leave_adjustment
    add foreign key (leave_type_id)
        references ohrm_leave_type(id) on delete cascade;

alter table ohrm_leave_adjustment
    add foreign key (emp_number)
        references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_leave_adjustment
    add foreign key (created_by_id)
        references ohrm_user(id) on delete set null;

alter table ohrm_leave_adjustment
    add foreign key (adjustment_type)
        references ohrm_leave_entitlement_type(id) on delete cascade;

alter table ohrm_leave_request
    add foreign key (emp_number)
        references hs_hr_employee (emp_number) on delete cascade;

alter table ohrm_leave_request
    add foreign key (leave_type_id)
        references ohrm_leave_type (id) on delete cascade;

alter table ohrm_leave
    add foreign key (leave_request_id)
        references ohrm_leave_request(id) on delete cascade;


/*
alter table ohrm_leave
    add foreign key (leave_type_id)
        references ohrm_leave_type (id) on delete cascade;
*/


alter table ohrm_leave_leave_entitlement
    add foreign key (entitlement_id)
        references ohrm_leave_entitlement (id) on delete cascade;

        /*
alter table ohrm_leave_leave_entitlement
    add foreign key (leave_id)
        references ohrm_leave (id) on delete cascade;
        */

alter table ohrm_leave_entitlement_adjustment
    add foreign key (entitlement_id)
        references ohrm_leave_entitlement (id) on delete cascade;

        /*
alter table ohrm_leave_entitlement_adjustment
    add foreign key (adjustment_id)
        references ohrm_leave_adjustment (id) on delete cascade;
        */


alter table ohrm_leave_comment
    add  foreign key (leave_id)
        references ohrm_leave(id) on delete cascade;

alter table ohrm_leave_comment
    add  foreign key (created_by_id)
        references ohrm_user(id) on delete set NULL;

/*
alter table ohrm_leave_comment
    add  foreign key (created_by_emp_number)
        references hs_hr_employee(emp_number) on delete cascade;
*/

alter table ohrm_leave_request_comment
    add  foreign key (leave_request_id)
        references ohrm_leave_request(id) on delete cascade;


alter table ohrm_leave_request_comment
    add foreign key (created_by_id)
        references ohrm_user(id) on delete set NULL;

/*
alter table ohrm_leave_request_comment
    add  foreign key (created_by_emp_number)
        references hs_hr_employee(emp_number) on delete cascade;
*/

alter table ohrm_menu_item
       add  foreign key (screen_id)
                             references ohrm_screen(id) on delete cascade;

alter table ohrm_user_role_data_group
       add  foreign key (user_role_id)
                             references ohrm_user_role(id) on delete cascade;

alter table ohrm_user_role_data_group
       add  foreign key (data_group_id)
                             references ohrm_data_group(id) on delete cascade;

alter table ohrm_email_subscriber
       add  foreign key (notification_id)
                             references ohrm_email_notification(id) on delete cascade;

alter table ohrm_email_template
    add foreign key (email_id)
        references ohrm_email(id) on delete cascade;

alter table ohrm_email_processor
    add foreign key (email_id)
        references ohrm_email(id) on delete cascade;

alter table ohrm_emp_termination
       add  foreign key (reason_id)
                             references ohrm_emp_termination_reason(id) on delete set null;

alter table ohrm_emp_termination
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_job_specification_attachment
       add  foreign key (job_title_id)
                             references ohrm_job_title(id) on delete cascade;

alter table ohrm_available_group_field
       add  foreign key (group_field_id)
                             references ohrm_group_field(group_field_id);

alter table ohrm_filter_field
       add  foreign key (report_group_id)
                             references ohrm_report_group(report_group_id) on delete cascade;

alter table ohrm_display_field
       add  foreign key (report_group_id)
                             references ohrm_report_group(report_group_id) on delete cascade;

alter table ohrm_display_field
       add  foreign key (display_field_group_id)
                             references ohrm_display_field_group(id) on delete set null;

alter table ohrm_composite_display_field
       add  foreign key (report_group_id)
                             references ohrm_report_group(report_group_id) on delete cascade;

alter table ohrm_composite_display_field
       add  foreign key (display_field_group_id)
                             references ohrm_display_field_group(id) on delete set null;

alter table ohrm_summary_display_field
       add  foreign key (display_field_group_id)
                             references ohrm_display_field_group(id) on delete set null;

alter table ohrm_selected_group_field
       add  foreign key (report_id)
                             references ohrm_report(report_id) on delete cascade;

alter table ohrm_selected_group_field
       add  foreign key (group_field_id)
                             references ohrm_group_field(group_field_id) on delete cascade;

alter table ohrm_selected_group_field
       add  foreign key (summary_display_field_id)
                             references ohrm_summary_display_field(summary_display_field_id);

alter table ohrm_selected_filter_field
       add  foreign key (report_id)
                             references ohrm_report(report_id) on delete cascade;

alter table ohrm_selected_filter_field
       add  foreign key (filter_field_id)
                             references ohrm_filter_field(filter_field_id) on delete cascade;

alter table ohrm_selected_display_field
       add  foreign key (report_id)
                             references ohrm_report(report_id) on delete cascade;

alter table ohrm_selected_display_field
       add  foreign key (display_field_id)
                             references ohrm_display_field(display_field_id) on delete cascade;

alter table ohrm_selected_composite_display_field
       add  foreign key (report_id)
                             references ohrm_report(report_id) on delete cascade;

alter table ohrm_selected_composite_display_field
       add  foreign key (composite_display_field_id)
                             references ohrm_composite_display_field(composite_display_field_id) on delete cascade;
/*
alter table ohrm_report
       add  foreign key (report_group_id)
                             references ohrm_report_group(report_group_id) on delete cascade;
                             */
/*
alter table ohrm_display_field_group
       add  foreign key (report_group_id)
                             references ohrm_report_group(report_group_id) on delete cascade;
*/

alter table ohrm_selected_display_field_group
       add  foreign key (report_id)
                             references ohrm_report(report_id) on delete cascade;

alter table ohrm_selected_display_field_group
       add  foreign key (display_field_group_id)
                             references ohrm_display_field_group(id) on delete cascade;

alter table ohrm_timesheet_action_log
       add  foreign key (performed_by)
                             references ohrm_user(id) on delete cascade;

alter table ohrm_job_interview
       add  foreign key (candidate_vacancy_id)
                             references ohrm_job_candidate_vacancy(id) on delete set null;

alter table ohrm_job_interview
       add  foreign key (candidate_id)
                             references ohrm_job_candidate(id) on delete cascade;

alter table ohrm_job_interview_interviewer
       add  foreign key (interview_id)
                             references ohrm_job_interview(id) on delete cascade;

alter table ohrm_job_interview_interviewer
       add  foreign key (interviewer_id)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_job_candidate_attachment
       add  foreign key (candidate_id)
                             references ohrm_job_candidate(id) on delete cascade;

alter table ohrm_job_vacancy_attachment
       add  foreign key (vacancy_id)
                             references ohrm_job_vacancy(id) on delete cascade;

alter table ohrm_job_interview_attachment
       add  foreign key (interview_id)
                             references ohrm_job_interview(id) on delete cascade;

alter table ohrm_job_candidate_history
       add  foreign key (candidate_id)
                             references ohrm_job_candidate(id) on delete cascade;

alter table ohrm_job_candidate_history
       add  foreign key (vacancy_id)
                             references ohrm_job_vacancy(id) on delete set null;

/*
alter table ohrm_job_candidate_history
       add  foreign key (interview_id)
                             references ohrm_job_interview(id) on delete set null;
*/

alter table ohrm_job_candidate_history
       add  foreign key (performed_by)
                             references hs_hr_employee(emp_number) on delete set null;

alter table ohrm_job_vacancy
       add  foreign key (job_title_code)
                             references ohrm_job_title(id) on delete cascade;

alter table ohrm_job_vacancy
       add  foreign key (hiring_manager_id)
                             references hs_hr_employee(emp_number) on delete set null;

alter table ohrm_job_candidate
       add  foreign key (added_person)
                             references hs_hr_employee(emp_number) on delete set null;

                             /*
alter table ohrm_job_candidate_vacancy
       add  foreign key (candidate_id)
                             references ohrm_job_candidate(id) on delete cascade;
                             */

alter table ohrm_job_candidate_vacancy
       add  foreign key (vacancy_id)
                             references ohrm_job_vacancy(id) on delete cascade;

                             /*
alter table ohrm_pay_grade_currency
       add  foreign key (currency_id)
                             references hs_hr_currency_type(currency_id) on delete cascade;
                             */

alter table ohrm_pay_grade_currency
       add  foreign key (pay_grade_id)
                             references ohrm_pay_grade(id) on delete cascade;

                             /*
alter table ohrm_location
       add  foreign key (country_code)
                             references hs_hr_country(cou_code) on delete cascade;
                             */

alter table hs_hr_jobtit_empstat
       add  foreign key (jobtit_code)
                             references ohrm_job_title(id) on delete cascade;

alter table hs_hr_jobtit_empstat
       add  foreign key (estat_code)
                             references ohrm_employment_status(id) on delete cascade;

alter table hs_hr_employee
       add  foreign key (work_station)
                             references ohrm_subunit(id) on delete set null;

alter table hs_hr_employee
       add  foreign key (nation_code)
                             references ohrm_nationality(id) on delete set null;

alter table hs_hr_employee
       add  foreign key (job_title_code)
                             references ohrm_job_title(id) on delete set null;

alter table hs_hr_employee
       add  foreign key (emp_status)
                             references ohrm_employment_status(id) on delete set null;

alter table hs_hr_employee
       add  foreign key (eeo_cat_code)
                             references ohrm_job_category(id) on delete set null;

                             /*
alter table hs_hr_employee
       add  foreign key (termination_id)
                             references ohrm_emp_termination(id) on delete set null;
*/

alter table hs_hr_emp_children
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_dependents
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_emergency_contacts
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_history_of_ealier_pos
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_emp_license
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_emp_license
       add  foreign key (license_id)
                             references ohrm_license(id) on delete cascade;

alter table hs_hr_emp_skill
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_skill
       add  foreign key (skill_id)
                             references ohrm_skill(id) on delete cascade;

alter table hs_hr_emp_attachment
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_picture
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_emp_education
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table ohrm_emp_education
       add  foreign key (education_id)
                             references ohrm_education(id) on delete cascade;

alter table hs_hr_emp_work_experience
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_passport
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_directdebit
       add  foreign key (salary_id)
                             references hs_hr_emp_basicsalary(id) on delete cascade;

alter table hs_hr_emp_member_detail
       add  foreign key (membship_code)
                             references ohrm_membership(id) on delete cascade;

alter table hs_hr_emp_member_detail
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_reportto
       add  foreign key (erep_sup_emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

                             /*
alter table hs_hr_emp_reportto
       add  foreign key (erep_sub_emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;
                             */

alter table hs_hr_emp_reportto
       add  foreign key (erep_reporting_mode)
                             references ohrm_emp_reporting_method(reporting_method_id) on delete cascade;

alter table hs_hr_emp_basicsalary
       add  foreign key (sal_grd_code)
                             references ohrm_pay_grade(id) on delete cascade;

alter table hs_hr_emp_basicsalary
       add  foreign key (currency_id)
                             references hs_hr_currency_type(currency_id) on delete cascade;

alter table hs_hr_emp_basicsalary
       add  foreign key (emp_number)
                             references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_basicsalary
       add  foreign key (payperiod_code)
                             references hs_hr_payperiod(payperiod_code) on delete cascade;

alter table hs_hr_emp_language add  foreign key (emp_number) references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_language add  foreign key (lang_id)  references ohrm_language(id) on delete cascade;

alter table hs_hr_emp_us_tax add  foreign key (emp_number) references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_emp_contract_extend
       add  foreign key (emp_number) references hs_hr_employee(emp_number) on delete cascade;

alter table hs_hr_mailnotifications
       add  foreign key (user_id) references ohrm_user(id) on delete cascade;

/*
alter table ohrm_project_activity
  add  foreign key (project_id) references ohrm_project (project_id) on delete cascade;
*/

/*
alter table ohrm_project_admin
  add  foreign key (project_id) references ohrm_project (project_id) on delete cascade, 
   foreign key (emp_number) references hs_hr_employee (emp_number) on delete cascade;
*/

/*
alter table ohrm_employee_work_shift
  add  foreign key (work_shift_id) references ohrm_work_shift (id) on delete cascade,
    foreign key (emp_number) references hs_hr_employee (emp_number) on delete cascade;
*/

alter table hs_hr_emp_locations add  foreign key (location_id) references ohrm_location(id) on delete cascade,
     foreign key (emp_number) references hs_hr_employee(emp_number) on delete cascade;

/*
alter table ohrm_user  add  foreign key (emp_number) references hs_hr_employee(emp_number) on delete cascade;
*/
alter table ohrm_user add  foreign key (user_role_id) references ohrm_user_role(id)  /* on delete restrict;*/

ALTER TABLE ohrm_operational_country
ADD CONSTRAINT fk_ohrm_operational_country_hs_hr_country
    FOREIGN KEY (country_code)
    REFERENCES hs_hr_country (cou_code)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

ALTER TABLE ohrm_work_week
ADD CONSTRAINT fk_ohrm_work_week_ohrm_operational_country
    FOREIGN KEY (operational_country_id)
    REFERENCES ohrm_operational_country (id)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

ALTER TABLE ohrm_holiday
ADD CONSTRAINT fk_ohrm_holiday_ohrm_operational_country
    FOREIGN KEY (operational_country_id)
    REFERENCES ohrm_operational_country (id)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

alter table ohrm_screen
       add  foreign key (module_id)
                             references ohrm_module(id) on delete cascade;
alter table ohrm_user_role_screen
       add  foreign key (user_role_id)
                             references ohrm_user_role(id) on delete cascade;
alter table ohrm_user_role_screen
       add  foreign key (screen_id)
                             references ohrm_screen(id) on delete cascade;

alter table ohrm_data_group_screen
    add foreign key (data_group_id) references ohrm_data_group(id) on delete cascade;

alter table ohrm_data_group_screen
    add foreign key (screen_id) references ohrm_screen(id) on delete cascade;

--
-- SET @admin_module_id := (SELECT id FROM ohrm_module WHERE name = 'admin');
--
-- INSERT INTO ohrm_screen (name,module_id,action_url) VALUES
-- ('Beacon Registration',@admin_module_id,'beaconRegistration');
--
-- SET @beacon_screen_id := (SELECT LAST_INSERT_ID());
--
-- SET @admin_menu_id := (SELECT id FROM ohrm_menu_item WHERE menu_title = 'Admin');

-- INSERT INTO ohrm_menu_item (menu_title, screen_id, parent_id, level, order_hint, url_extras, status) VALUES
-- ('Beacon', @beacon_screen_id, @admin_menu_id, 2, 1000, NULL, 1);
--
-- SET @admin_role_id := (SELECT id FROM ohrm_user_role WHERE name = 'Admin');
--
-- INSERT INTO ohrm_user_role_screen (user_role_id, screen_id, can_read, can_create, can_update, can_delete) VALUES
-- (@admin_role_id, @beacon_screen_id, 1, 1, 1, 1);

CREATE TABLE ohrm_datapoint_type (
    id INT IDENTITY,
    name VARCHAR(100) NOT NULL,
    action_class VARCHAR(100) NOT NULL,
    PRIMARY KEY(id)
) ;


CREATE TABLE ohrm_datapoint (
    id INT IDENTITY,
    name VARCHAR(100),
    datapoint_type_id INT NOT NULL,
    definition text NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (datapoint_type_id) REFERENCES ohrm_datapoint_type (id) ON DELETE CASCADE
) ;

CREATE TABLE ohrm_beacon_notification (
    id INT IDENTITY,
    name VARCHAR(100) NOT NULL,
    expiry_date TIMESTAMP NOT NULL,
    definition text NOT NULL, PRIMARY KEY(id)
);

CREATE TABLE ohrm_login (
    id INT IDENTITY,
    user_id BIGINT NOT NULL,
    user_name VARCHAR(255),
    user_role_name TEXT NOT NULL,
    user_role_predefined TINYINT NOT NULL,
    login_time TIMESTAMP, 
    PRIMARY KEY(id)
) ;

CREATE TABLE ohrm_kpi (
  id bigint NOT NULL IDENTITY,
  job_title_code varchar(10) DEFAULT NULL,
  kpi_indicators varchar(255) DEFAULT NULL,
  min_rating int DEFAULT 0,
  max_rating int DEFAULT 0,
  default_kpi smallint DEFAULT NULL,
  deleted_at datetime DEFAULT NULL,
  PRIMARY KEY (id)
)  ;


CREATE TABLE ohrm_performance_review (
  id int NOT NULL IDENTITY,
  status_id int DEFAULT NULL,
  employee_number int DEFAULT NULL,
  work_period_start date DEFAULT NULL,
  work_period_end date DEFAULT NULL,
  job_title_code int DEFAULT NULL,
  department_id int DEFAULT NULL,
  due_date date DEFAULT NULL,
  completed_date date DEFAULT NULL,
  activated_date DATETIME DEFAULT NULL,
  final_comment text,
  final_rate DECIMAL(18, 2) DEFAULT NULL,
  PRIMARY KEY (id),
  INDEX employee_number (employee_number)
) ;

CREATE TABLE ohrm_reviewer (
  id int NOT NULL IDENTITY,
  review_id int DEFAULT NULL,
  employee_number int DEFAULT NULL,
  status int DEFAULT NULL,
  reviewer_group_id int DEFAULT NULL,
  completed_date DATETIME DEFAULT NULL,
  comment text,
  PRIMARY KEY (id),
  INDEX review_id (review_id)
)  ;

CREATE TABLE ohrm_reviewer_group (
  id int NOT NULL IDENTITY,
  name varchar(50) DEFAULT NULL,
  piority int DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE ohrm_reviewer_rating (
  id int NOT NULL IDENTITY,
  rating DECIMAL(18, 2) DEFAULT NULL,
  kpi_id int DEFAULT NULL,
  review_id int DEFAULT NULL,
  reviewer_id int NOT NULL,
  comment text,
  PRIMARY KEY (id),
  INDEX review_id (review_id),
  INDEX reviewer_id (reviewer_id)
); 

ALTER TABLE ohrm_performance_review
  ADD  FOREIGN KEY (employee_number) REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ;

ALTER TABLE ohrm_reviewer
  ADD  FOREIGN KEY (review_id) REFERENCES ohrm_performance_review (id) ON DELETE CASCADE ;

ALTER TABLE ohrm_reviewer_rating
  ADD  FOREIGN KEY (reviewer_id) REFERENCES ohrm_reviewer (id) ON DELETE CASCADE ;

/*
ALTER TABLE ohrm_reviewer_rating
  ADD  FOREIGN KEY (review_id) REFERENCES ohrm_performance_review (id) ON DELETE CASCADE ;
*/

CREATE TABLE ohrm_performance_track (
  id int NOT NULL IDENTITY,
  emp_number int NOT NULL,
  tracker_name varchar(200) NOT NULL,
  added_date datetime NULL DEFAULT NULL,
  added_by int DEFAULT NULL,
  status int DEFAULT NULL,
  modified_date timestamp NULL,
  PRIMARY KEY (id),
  INDEX ohrm_performance_track_fk1_idx (emp_number),
  INDEX ohrm_performance_track_fk2_idx (added_by)
  /*
  CONSTRAINT ohrm_performance_track_fk1 FOREIGN KEY (emp_number) REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ohrm_performance_track_fk2 FOREIGN KEY (added_by) REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE CASCADE
  */
) 


CREATE TABLE ohrm_performance_tracker_log (
  id int NOT NULL IDENTITY,
  performance_track_id int DEFAULT NULL,
  log varchar(150) DEFAULT NULL,
  comment varchar(3000) DEFAULT NULL,
  status int DEFAULT NULL,
  added_date timestamp NULL,
  modified_date datetime NULL,
  reviewer_id int DEFAULT NULL,
  achievement varchar(45) DEFAULT NULL,
  user_id int DEFAULT NULL,
  PRIMARY KEY (id),
  INDEX ohrm_performance_tracker_log_fk1_idx (performance_track_id),
  INDEX ohrm_performance_tracker_log_fk2_idx (reviewer_id),
  INDEX fk_ohrm_performance_tracker_log_1 (user_id),
  CONSTRAINT fk_ohrm_performance_tracker_log_2 FOREIGN KEY (user_id) REFERENCES ohrm_user (id) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ohrm_performance_tracker_log_fk1 FOREIGN KEY (performance_track_id) REFERENCES ohrm_performance_track (id) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ohrm_performance_tracker_log_fk2 FOREIGN KEY (reviewer_id) REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE CASCADE
) ;


CREATE TABLE ohrm_performance_tracker_reviewer (
  id int NOT NULL IDENTITY,
  performance_track_id int NOT NULL,
  reviewer_id int NOT NULL,
  added_date timestamp NULL,
  status int DEFAULT NULL,
  PRIMARY KEY (id),
  INDEX ohrm_performance_tracker_reviewer_fk1_idx (performance_track_id),
  INDEX ohrm_performance_tracker_reviewer_fk2_idx (reviewer_id),
  CONSTRAINT ohrm_performance_tracker_reviewer_fk1 FOREIGN KEY (performance_track_id) REFERENCES ohrm_performance_track (id) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ohrm_performance_tracker_reviewer_fk2 FOREIGN KEY (reviewer_id) REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE CASCADE
) ;

CREATE TABLE ohrm_ws_consumer (
    app_id INT  IDENTITY,
    app_token VARCHAR(10) NOT NULL,
    app_name VARCHAR(50) DEFAULT NULL,
    status TINYINT NOT NULL DEFAULT 1,
    PRIMARY KEY(app_id)
) ;

CREATE TABLE ohrm_oauth_client ( client_id VARCHAR(80) NOT NULL, client_secret VARCHAR(80) NOT NULL, redirect_uri VARCHAR(2000)  NOT NULL, CONSTRAINT client_id_pk PRIMARY KEY (client_id));
CREATE TABLE ohrm_oauth_access_token (access_token VARCHAR(40) NOT NULL, client_id VARCHAR(80) NOT NULL, user_id VARCHAR(255), expires TIMESTAMP NOT NULL,scope VARCHAR(2000), CONSTRAINT access_token_pk PRIMARY KEY (access_token));
CREATE TABLE ohrm_oauth_authorization_code (authorization_code VARCHAR(40) NOT NULL, client_id VARCHAR(80) NOT NULL, user_id VARCHAR(255), redirect_uri VARCHAR(2000) NOT NULL, expires TIMESTAMP NOT NULL, scope VARCHAR(2000), CONSTRAINT auth_code_pk PRIMARY KEY (authorization_code));
CREATE TABLE ohrm_oauth_refresh_token ( refresh_token VARCHAR(40) NOT NULL, client_id VARCHAR(80) NOT NULL, user_id VARCHAR(255), expires TIMESTAMP NOT NULL, scope VARCHAR(2000), CONSTRAINT refresh_token_pk PRIMARY KEY (refresh_token));
CREATE TABLE ohrm_oauth_user (username VARCHAR(255) NOT NULL, password VARCHAR(2000), first_name VARCHAR(255), last_name VARCHAR(255), CONSTRAINT username_pk PRIMARY KEY (username));

CREATE TABLE ohrm_openid_provider (
  id int NOT NULL IDENTITY,
  provider_name varchar(40) DEFAULT NULL,
  provider_url varchar(255) DEFAULT NULL,
  status tinyint NOT NULL DEFAULT 1,
  PRIMARY KEY (id)
)  ;

CREATE TABLE ohrm_auth_provider_extra_details (
    id INT PRIMARY KEY IDENTITY,
    provider_id INT NOT NULL,
    provider_type INT,
    client_id TEXT,
    client_secret TEXT,
    developer_key TEXT,
    CONSTRAINT ohrm_openid_provider_fk FOREIGN KEY (provider_id) REFERENCES ohrm_openid_provider (id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE  ohrm_openid_user_identity (
  user_id int ,
  provider_id int,
  user_identity varchar(255) DEFAULT NULL
) ;

ALTER TABLE ohrm_openid_user_identity
  ADD CONSTRAINT ohrm_user_identity_ibfk_1 FOREIGN KEY (user_id) REFERENCES ohrm_user (id) ON DELETE SET NULL;
ALTER TABLE ohrm_openid_user_identity
  ADD CONSTRAINT ohrm_user_identity_ibfk_2 FOREIGN KEY (provider_id) REFERENCES ohrm_openid_provider (id) ON DELETE SET NULL;

CREATE TABLE abstract_display_field  (
    id BIGINT IDENTITY,
    report_group_id BIGINT NOT NULL,
    name VARCHAR(255) NOT NULL,
    label VARCHAR(255) NOT NULL,
    field_alias VARCHAR(255),
    is_sortable VARCHAR(10) NOT NULL,
    sort_order VARCHAR(255),
    sort_field VARCHAR(255),
    element_type VARCHAR(255) NOT NULL,
    element_property TEXT NOT NULL,
    width VARCHAR(255) NOT NULL,
    is_exportable VARCHAR(10),
    text_alignment_style VARCHAR(20),
    is_value_list TINYINT NOT NULL,
    display_field_group_id BIGINT ,
    default_value VARCHAR(255),
    is_encrypted TINYINT NOT NULL,
    is_meta TINYINT DEFAULT 0 NOT NULL,
PRIMARY KEY(id)) ;

CREATE TABLE ohrm_employee_event (
  event_id int NOT NULL IDENTITY,
  employee_id int NOT NULL DEFAULT 0,
  type varchar(45) DEFAULT NULL,
  event varchar(45) DEFAULT NULL,
  note varchar(150) DEFAULT NULL,
  created_date datetime DEFAULT NULL,
  created_by varchar(45) DEFAULT NULL,
  PRIMARY KEY (event_id)
)  ;

/*ALTER TABLE hs_hr_config CHANGE COLUMN value value TEXT NOT NULL ;*/

CREATE TABLE ohrm_marketplace_addon (
  addon_id INT,
  title VARCHAR(100),
  date TIMESTAMP,
  status VARCHAR(30),
  version VARCHAR(100),
  plugin_name VARCHAR(255),
 [type] varchar(100) default 'free' CHECK([type] IN ('paid','free')),





  PRIMARY KEY(addon_id)
) ;

CREATE  TABLE ohrm_reset_password (
  id BIGINT  IDENTITY,
  reset_email VARCHAR(60) NOT NULL,
  reset_request_date TIMESTAMP NOT NULL ,
  reset_code VARCHAR(200) NOT NULL ,
  PRIMARY KEY(id));

--
-- Table structure for table ohrm_buzz_post
--
CREATE TABLE ohrm_buzz_post (
  id bigint NOT NULL IDENTITY,
  employee_number int,
  text text ,
  post_time datetime NOT NULL,
  updated_at timestamp,
  PRIMARY KEY (id),
  INDEX employee_number (employee_number)
)
--
-- Constraints for table ohrm_buzz_post
--
ALTER TABLE ohrm_buzz_post
  ADD CONSTRAINT buzzPostEmployee FOREIGN KEY (employee_number)
    REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Table structure for table ohrm_buzz_share
--
CREATE TABLE ohrm_buzz_share (
  id bigint NOT NULL IDENTITY,
  post_id bigint NOT NULL,
  employee_number int ,
  number_of_likes int DEFAULT NULL,
  number_of_unlikes int DEFAULT NULL,
  number_of_comments int DEFAULT NULL,
  share_time datetime NOT NULL,
  type tinyint DEFAULT NULL,
  text text,
  updated_at timestamp,
  PRIMARY KEY (id),
  INDEX post_id (post_id),
  INDEX employee_number (employee_number)
) ;
--
-- Constraints for table ohrm_buzz_share
--

/*
   ALTER TABLE ohrm_buzz_share
   ADD CONSTRAINT buzzShareEmployee FOREIGN KEY (employee_number)
   REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION,
   CONSTRAINT buzzSharePost FOREIGN KEY (post_id)
   REFERENCES ohrm_buzz_post (id) ON DELETE CASCADE ON UPDATE NO ACTION;
*/
--
-- Table structure for table ohrm_buzz_comment
--
CREATE TABLE ohrm_buzz_comment (
  id bigint NOT NULL IDENTITY,
  share_id bigint NOT NULL,
  employee_number int ,
  number_of_likes int DEFAULT NULL,
  number_of_unlikes int DEFAULT NULL,
  comment_text text,
  comment_time datetime NOT NULL,
  updated_at timestamp ,
  PRIMARY KEY (id),
  INDEX share_id (share_id),
  INDEX employee_number (employee_number)
) ;
--
-- Constraints for table ohrm_buzz_comment
--
ALTER TABLE ohrm_buzz_comment
  ADD CONSTRAINT buzzComentedEmployee FOREIGN KEY (employee_number)
    REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION,
   CONSTRAINT buzzComentOnShare FOREIGN KEY (share_id)
    REFERENCES ohrm_buzz_share (id) ON DELETE CASCADE ON UPDATE NO ACTION;
--
-- Table structure for table ohrm_buzz_like_on_comment
--
CREATE TABLE  ohrm_buzz_like_on_comment (
  id bigint NOT NULL IDENTITY,
  comment_id bigint NOT NULL,
  employee_number int ,
  like_time datetime NOT NULL,
  PRIMARY KEY (id),
  INDEX comment_id (comment_id),
  INDEX employee_number (employee_number)
)  ;
--
-- Constraints for table ohrm_buzz_comment_like
--
/*
ALTER TABLE ohrm_buzz_like_on_comment
  ADD CONSTRAINT buzzCommentLikeEmployee FOREIGN KEY (employee_number)
    REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION,
   CONSTRAINT buzzLikeOnComment FOREIGN KEY (comment_id)
    REFERENCES ohrm_buzz_comment (id) ON DELETE CASCADE ON UPDATE NO ACTION;
*/
--
-- Table structure for table ohrm_buzz_share_like
--
CREATE TABLE  ohrm_buzz_like_on_share (
  id bigint NOT NULL IDENTITY,
  share_id bigint NOT NULL,
  employee_number int ,
  like_time datetime NOT NULL,
  PRIMARY KEY (id),
  INDEX share_id (share_id),
  INDEX employee_number (employee_number)
) 
--
-- Constraints for table ohrm_buzz_share_like
--
ALTER TABLE ohrm_buzz_like_on_share
  ADD CONSTRAINT buzzShareLikeEmployee FOREIGN KEY (employee_number)
    REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION,
   CONSTRAINT buzzLikeOnshare FOREIGN KEY (share_id)
    REFERENCES ohrm_buzz_share (id) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Table structure for table ohrm_buzz_photo
--
CREATE TABLE ohrm_buzz_photo (
  id bigint NOT NULL IDENTITY,
  post_id bigint NOT NULL,
  photo image,
  filename varchar(100) DEFAULT NULL,
  file_type varchar(50) DEFAULT NULL,
  size varchar(20) DEFAULT NULL,
  width varchar(20) DEFAULT NULL,
  height varchar(20) DEFAULT NULL,
  PRIMARY KEY (id),
  INDEX attachment_id (post_id)
) ;
--
-- Constraints for table ohrm_buzz_photo
--
ALTER TABLE ohrm_buzz_photo
  ADD CONSTRAINT photoAttached FOREIGN KEY (post_id)
    REFERENCES ohrm_buzz_post (id) ON DELETE CASCADE;

--
-- Table structure for table ohrm_buzz_link
--

CREATE TABLE  ohrm_buzz_link (
  id bigint NOT NULL IDENTITY,
  post_id bigint NOT NULL,
  link text NOT NULL,
  type tinyint DEFAULT NULL,
  title VARCHAR( 600 ) NULL,
  description text,
  PRIMARY KEY (id),
  INDEX attachment_id (post_id),
  INDEX photo_id (post_id)
) ;
--
-- Constraints for table ohrm_buzz_link
--
ALTER TABLE ohrm_buzz_link
  ADD CONSTRAINT linkAttached FOREIGN KEY (post_id)
    REFERENCES ohrm_buzz_post (id) ON DELETE CASCADE;

--
-- Table structure for table ohrm_buzz_unlike_on_comment
--
CREATE TABLE  ohrm_buzz_unlike_on_comment (
  id bigint NOT NULL IDENTITY,
  comment_id bigint NOT NULL,
  employee_number int ,
  like_time datetime NOT NULL,
  PRIMARY KEY (id),
  INDEX comment_id (comment_id),
  INDEX employee_number (employee_number)
) ;
--
-- Constraints for table ohrm_buzz_comment_like
--
/*
ALTER TABLE ohrm_buzz_unlike_on_comment
  ADD CONSTRAINT buzzCommentUnLikeEmployee FOREIGN KEY (employee_number)
    REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION,
   CONSTRAINT buzzUnLikeOnComment FOREIGN KEY (comment_id)
    REFERENCES ohrm_buzz_comment (id) ON DELETE CASCADE ON UPDATE NO ACTION;
*/
--
-- Table structure for table ohrm_buzz_share_like
--
CREATE TABLE ohrm_buzz_unlike_on_share (
  id bigint NOT NULL IDENTITY,
  share_id bigint NOT NULL,
  employee_number int ,
  like_time datetime NOT NULL,
  PRIMARY KEY (id),
  INDEX share_id (share_id),
  INDEX employee_number (employee_number)
) ;
--
-- Constraints for table ohrm_buzz_share_like
--
ALTER TABLE ohrm_buzz_unlike_on_share
  ADD CONSTRAINT buzzShareUnLikeEmployee FOREIGN KEY (employee_number)
    REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION,
   CONSTRAINT buzzUNLikeOnshare FOREIGN KEY (share_id)
    REFERENCES ohrm_buzz_share (id) ON DELETE CASCADE ON UPDATE NO ACTION;

CREATE TABLE  ohrm_buzz_notification_metadata (
  emp_number int ,
  last_notification_view_time datetime DEFAULT NULL,
  last_buzz_view_time datetime DEFAULT NULL,
  last_clear_notifications datetime DEFAULT NULL,
  PRIMARY KEY (emp_number)
)  ;

ALTER TABLE ohrm_buzz_notification_metadata
  ADD CONSTRAINT notificationMetadata FOREIGN KEY (emp_number)
    REFERENCES hs_hr_employee (emp_number) ON DELETE CASCADE ON UPDATE NO ACTION;

CREATE TABLE ohrm_oauth_scope (
  scope text,
  is_default bit not null default(0)
) ;

ALTER TABLE ohrm_oauth_client ADD grant_types VARCHAR(80) NULL DEFAULT NULL;
ALTER TABLE ohrm_oauth_client ADD scope VARCHAR(4000) NULL DEFAULT NULL;

CREATE TABLE ohrm_rest_api_usage (
    id INT NOT NULL IDENTITY ,
    client_id VARCHAR(255) NULL DEFAULT NULL ,
    user_id VARCHAR(255) NULL DEFAULT NULL ,
    scope VARCHAR(20) NULL DEFAULT NULL,
    method VARCHAR(20) NULL DEFAULT NULL ,
    module VARCHAR(20) NULL DEFAULT NULL ,
    action VARCHAR(50) NULL DEFAULT NULL ,
    path VARCHAR(255) NULL DEFAULT NULL ,
    parameters text NULL DEFAULT NULL ,
    created_at TIMESTAMP NOT NULL ,
    PRIMARY KEY (id)
) ;

CREATE TABLE ohrm_i18n_group (
  id INT PRIMARY KEY NOT NULL IDENTITY,
  name VARCHAR(255),
  title VARCHAR(255) DEFAULT NULL
);

CREATE TABLE ohrm_i18n_language (
  id INT PRIMARY KEY NOT NULL IDENTITY,
  name VARCHAR(255) DEFAULT NULL,
  code VARCHAR(100) NOT NULL UNIQUE,
  enabled TINYINT  NOT NULL DEFAULT 1,
  added TINYINT  NOT NULL DEFAULT 0,
  modified_at DATETIME DEFAULT NULL
);

CREATE TABLE ohrm_i18n_lang_string (
  id INT PRIMARY KEY NOT NULL IDENTITY,
  unit_id INT NOT NULL,
  source_id INT,
  group_id INT DEFAULT NULL,
  value TEXT NOT NULL,
  note TEXT,
  version VARCHAR(20) DEFAULT NULL
);

CREATE TABLE ohrm_i18n_translate (
  id INT PRIMARY KEY NOT NULL IDENTITY,
  lang_string_id INT NOT NULL,
  language_id INT NOT NULL,
  value TEXT,
  translated TINYINT  DEFAULT 1,
  customized TINYINT  DEFAULT 0,
  modified_at TIMESTAMP NOT NULL 
);

CREATE TABLE ohrm_i18n_source (
  id INT PRIMARY KEY NOT NULL IDENTITY,
  source text NOT NULL,
  modified_at DATETIME
);

ALTER TABLE ohrm_i18n_lang_string
    ADD CONSTRAINT groupId FOREIGN KEY (group_id)
        REFERENCES ohrm_i18n_group (id) ON DELETE SET NULL;

ALTER TABLE ohrm_i18n_translate
    ADD CONSTRAINT languageId FOREIGN KEY (language_id)
        REFERENCES ohrm_i18n_language (id);

ALTER TABLE ohrm_i18n_translate
    ADD CONSTRAINT langStringId FOREIGN KEY (lang_string_id)
        REFERENCES ohrm_i18n_lang_string (id) ON DELETE CASCADE;

ALTER TABLE ohrm_i18n_lang_string
    ADD CONSTRAINT sourceId FOREIGN KEY (source_id)
        REFERENCES ohrm_i18n_source (id) ON DELETE CASCADE;

ALTER TABLE ohrm_i18n_translate
    ADD CONSTRAINT translateUniqueId UNIQUE (lang_string_id, language_id);
