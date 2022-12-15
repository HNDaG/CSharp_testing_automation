Feature: Dropbox api file management

  Scenario: Get file metadata
    Given I have a file in dropbox
    When I send request to get file metadata
    Then I should see my file metadata

  Scenario: Delete file
    Given I have a file in dropbox 
    When I send request to delete file
    Then I should not see my file

  Scenario: Upload file
    Given I have a file to upload
    When I send request to upload file
    Then I should see my file uploaded

